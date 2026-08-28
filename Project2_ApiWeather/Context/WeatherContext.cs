using Microsoft.EntityFrameworkCore;
using Project2_ApiWeather.Entities;

namespace Project2_ApiWeather.Context
{
    public class WeatherContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=EMIRHAN\\SQLEXPRESS;initial catalog=Db2Project8;integrated Security=true;TrustServerCertificate=True");
        }
        public DbSet<City> Cities { get; set; }
    }
}
