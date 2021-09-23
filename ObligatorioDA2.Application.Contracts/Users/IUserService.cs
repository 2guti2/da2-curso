using ObligatorioDA2.Application.Contracts.Users.Dtos;

namespace ObligatorioDA2.Application.Contracts.Users
{
    public interface IUserService
    {
        UserOutputDto Create(UserInputDto user);
        bool IsAuthorized(string username, string password);
        bool CanPerform(string username, string action);
    }
}