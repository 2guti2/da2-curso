namespace ObligatorioDA2.Application.Contracts.Users.Dtos
{
    public class LoginOutputDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Roles { get; set; }
    }
}