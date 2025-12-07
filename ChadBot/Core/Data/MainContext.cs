using ChadBot.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChadBot.Core.Data
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public string DbPath { get; }

        public MainContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "chatbot.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
