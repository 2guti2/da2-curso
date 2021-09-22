using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace ObligatorioDA2.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [Column(name: "PasswordHash")]
        private string _passwordHash;

        public static readonly Expression<Func<User, string>> PasswordHashExpression = u => u._passwordHash;

        public string Password
        {
            set => _passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
        }

        public virtual ICollection<WeatherForecast> Forecasts { get; set; }

        public bool IsPasswordValid(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, _passwordHash);
        }
    }
}
