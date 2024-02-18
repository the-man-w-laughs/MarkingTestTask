using MarkingTestTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MarkingTestTask.DAL
{
    public class MarkingTestTaskDBContext : DbContext
    {

        private readonly IConfiguration configuration;
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BoxModel> Boxes { get; set; }
        public DbSet<PalletModel> Pallets { get; set; }
        public DbSet<MissionModel> Missions { get; set; }

        public MarkingTestTaskDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            // Создание базы данных, если она еще не создана
            Database.EnsureCreated();
        }

        // Переопределение метода для настройки параметров соединения с базой данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Получение строки подключения к базе данных из конфигурации
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            // Использование Sqlite в качестве провайдера базы данных 
            optionsBuilder.UseSqlite(connectionString);
        }

        // Переопределение метода для настройки модели данных при помощи Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Применение конфигураций модели данных из текущей сборки
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
