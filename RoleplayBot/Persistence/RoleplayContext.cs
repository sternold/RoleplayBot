using Microsoft.EntityFrameworkCore;
using RoleplayBot.Character.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoleplayBot.Persistence
{
    public class RoleplayContext : DbContext
    {
        public DbSet<Charactersheet> Charactersheets { get; set; } 

        public RoleplayContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=entities.db");
        }
    }
}
