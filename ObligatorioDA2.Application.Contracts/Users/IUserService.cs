using System.Collections.Generic;
using ObligatorioDA2.Application.Contracts.Users.Dtos;

namespace ObligatorioDA2.Application.Contracts.Users
{
    public interface IUserService
    {
        UserOutputDto Create(UserInputDto user);
        bool AuthenticationWorks(string username, string password);
        bool CanPerform(string username, string action);
        void Assign(int userId, string role);
        IEnumerable<UserOutputDto> ReadAll();
        IEnumerable<UserOutputDto> ReadAllWithUsername(string username);
        LoginOutputDto CreateSession(LoginInputDto input);
    }
}