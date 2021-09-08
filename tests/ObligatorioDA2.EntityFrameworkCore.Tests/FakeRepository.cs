using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore.Repositories;

namespace ObligatorioDA2.EntityFrameworkCore.Tests
{
    public class FakeRepository : BaseRepository<WeatherForecast>
    {
        public FakeRepository(Context context)
        {
            Context = context;
        }

        public override WeatherForecast Read(int id)
        {
            return new WeatherForecast { Id = id };
        }
    }
}