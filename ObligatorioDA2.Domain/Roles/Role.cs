using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioDA2.Domain.Roles
{
    public abstract class Role
    {
        public int Id { get; set; }

        [NotMapped]
        public virtual List<Action> Actions { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}