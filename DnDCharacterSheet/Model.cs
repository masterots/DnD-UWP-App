using DnDCharacterSheet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace DnDCharacterSheet
{
    public class DnDCharacterSheetContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Weapons);
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Armor);
            modelBuilder.Entity<Weapon>()
                .HasMany(w => w.Characters);
            modelBuilder.Entity<Armor>()
                .HasMany(a => a.Characters);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var databaseFile = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Data", "DnDCharacterSheet.db");
            //optionsBuilder.UseSqlite($"Data Source={databaseFile}");
            var connection = @"Filename=DnDCharacterSheet_CF.db";
            optionsBuilder.UseSqlite(connection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
