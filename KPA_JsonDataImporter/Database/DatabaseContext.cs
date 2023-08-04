using KPA_JsonDataImporter.Models;
using Microsoft.EntityFrameworkCore;

namespace KPA_JsonDataImporter.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ExampleDB");
        }

        public DbSet<ExampleModel> ExampleModels { get; set; }
    }
}
