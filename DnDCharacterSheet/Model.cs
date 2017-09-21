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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var databaseFile = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Data", "DnDCharacterSheet_CF.db");
            optionsBuilder.UseSqlite($"Data Source={databaseFile}");
        }

    }
}
