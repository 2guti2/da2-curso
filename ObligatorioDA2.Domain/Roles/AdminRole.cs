using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioDA2.Domain.Roles
{
    public class AdminRole : Role
    {
        [NotMapped]
        public override List<Action> Actions => new()
        {
            Action.CreateForecasts,
            Action.ReadForecasts,
            Action.UpdateForecasts,
            Action.DeleteForecasts
        };
    }
}