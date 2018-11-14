using Microsoft.EntityFrameworkCore;



namespace DataLayer
{
        public sealed class CityContext : DbContext
        {
            public CityContext(DbContextOptions<CityContext> options) : base(options)
            {
                Database.EnsureCreated();
            }

            public DbSet<City> Cities { get; set; }
            public DbSet<Poi> Pois { get; set; }

}
}
