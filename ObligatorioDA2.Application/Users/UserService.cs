using System.Linq;
using ObligatorioDA2.Application.Contracts.Users;
using ObligatorioDA2.Application.Contracts.Users.Dtos;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore.Contracts;

namespace ObligatorioDA2.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;

        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public UserOutputDto Create(UserInputDto input)
        {
            var user = new User
            {
                Username = input.Username,
                Password = input.Password
            };

            _userRepo.Create(user);
            return Mapper.ToDto(_userRepo.Read(user.Id));
        }

        public bool IsAuthorized(string username, string password)
        {
            User user = _userRepo.ReadAllWhere(u => u.Username == username).FirstOrDefault();
            return user != null && user.IsPasswordValid(password);
        }
    }
}