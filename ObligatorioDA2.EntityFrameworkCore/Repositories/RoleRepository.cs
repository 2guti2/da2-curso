using System.Linq;
using ObligatorioDA2.Domain.Roles;

namespace ObligatorioDA2.EntityFrameworkCore.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(Context context)
        {
            Context = context;
        }

        public override Role Read(int id)
        {
            return Context.Roles.FirstOrDefault(r => r.Id == id);
        }
    }
}