using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using ObligatorioDA2.Domain.Roles;

namespace ObligatorioDA2.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [Column(name: "PasswordHash")]
        private string _passwordHash;

        public static readonly Expression<Func<User, string>> PasswordHashExpression = u => u._passwordHash;

        public const string DefaultRole = "MemberRole";

        public string Password
        {
            set => _passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
        }

        public virtual ICollection<WeatherForecast> Forecasts { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

        public bool IsPasswordValid(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, _passwordHash);
        }

        public bool CanPerform(string action)
        {
            var exists = false;
            foreach (Role role in Roles)
            {
                exists |= role.Actions.Exists(a => a.ToString().Equals(action, StringComparison.OrdinalIgnoreCase));
            }

            return exists;
        }

        public void Assign(IEnumerable<Role> availableRoles, string inputRole)
        {
            Role role =
                availableRoles.FirstOrDefault(r =>
                    r.GetType().BaseType.ToString().Contains(inputRole, StringComparison.OrdinalIgnoreCase));
            if (!Roles.Contains(role))
            {
                Roles.Add(role);
            }
        }
    }
}
