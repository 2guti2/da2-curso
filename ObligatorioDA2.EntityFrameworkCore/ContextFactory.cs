using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ObligatorioDA2.EntityFrameworkCore
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Context>();

            builder.UseSqlServer("Server=localhost,1433;Database=ObligatorioDA2;User Id=sa;Password=Passw0rd!;");

            return new Context(builder.Options);
        }
    }
}