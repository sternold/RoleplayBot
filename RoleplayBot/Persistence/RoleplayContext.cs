using Microsoft.EntityFrameworkCore;
using RoleplayBot.Character.Models;

namespace RoleplayBot.Persistence
{
    public class RoleplayContext : DbContext
    {
        public DbSet<Charactersheet> Charactersheets { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=entities.db");
        }
    }
}
