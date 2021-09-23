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
            User user = Mapper.ToModel(input);
            _userRepo.Create(user);
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
            user.Assign(role);
            _userRepo.Update(user);
        }
    }
}