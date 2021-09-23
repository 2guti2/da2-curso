using System.Linq;
using ObligatorioDA2.Domain;

namespace ObligatorioDA2.EntityFrameworkCore.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(Context context)
        {
            Context = context;
        }

        public override User Read(int id)
        {
            return Context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}