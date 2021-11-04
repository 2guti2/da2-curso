using System;
using System.Collections.Generic;
using System.Linq;
using ObligatorioDA2.Application.Contracts.Users;
using ObligatorioDA2.Application.Contracts.Users.Dtos;
using ObligatorioDA2.Domain;
using ObligatorioDA2.Domain.Roles;
using ObligatorioDA2.EntityFrameworkCore.Contracts;

namespace ObligatorioDA2.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Role> _roleRepo;

        public UserService(IRepository<User> userRepo, IRepository<Role> roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        public UserOutputDto Create(UserInputDto input)
        {
            User user = Mapper.ToModel(input);
            _userRepo.Create(user);
            Assign(user.Id, User.DefaultRole);
            return Mapper.ToDto(_userRepo.Read(user.Id));
        }

        public bool AuthenticationWorks(string username, string password)
        {
            User user = _userRepo.ReadAllWhere(u => u.Username == username).FirstOrDefault();
            return user != null && user.IsPasswordValid(password);
        }

        public bool CanPerform(string username, string action)
        {
            User user = _userRepo.ReadAllWhere(u => u.Username == username).FirstOrDefault();
            return user != null && user.CanPerform(action);
        }

        public void Assign(int userId, string role)
        {
            User user = _userRepo.Read(userId);
            user.Assign(AvailableRoles(), role);
            _userRepo.Update(user);
        }

        public IEnumerable<UserOutputDto> ReadAll()
        {
            IEnumerable<User>? users = _userRepo.ReadAll();
            return users.Select(Mapper.ToDto);
        }

        public IEnumerable<UserOutputDto> ReadAllWithUsername(string username)
        {
            IEnumerable<User>? users = _userRepo.ReadAllWhere(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            return users.Select(Mapper.ToDto);
        }

        public LoginOutputDto CreateSession(LoginInputDto input)
        {
            User user = _userRepo.ReadAllWhere(u => u.Username == input.Username).FirstOrDefault();
            IEnumerable<string>? roles = user.Roles.Select(r => r.GetType().ToString().Split(".").Last().Split("Role").First());
            if (user.IsPasswordValid(input.Password))
            {
                return new LoginOutputDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Token = BuildToken(input),
                    Roles = string.Join(',', roles)
                };
            }

            throw new UnauthorizedAccessException();
        }

        private string BuildToken(LoginInputDto input)
        {
            return Base64Encode($"{input.Username}:{input.Password}");
        }

        private static string Base64Encode(string plainText) {
            byte[]? plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private IEnumerable<Role> AvailableRoles()
        {
            if (!_roleRepo.ReadAll().Any())
            {
                _roleRepo.Create(new AdminRole());
                _roleRepo.Create(new MemberRole());
            }

            IEnumerable<string> roleTypes = _roleRepo.ReadAll().Select(r => r.GetType().ToString()).Distinct();
            return roleTypes.Select(roleType => _roleRepo.First(r => r.GetType().ToString() == roleType));
        }
    }
}