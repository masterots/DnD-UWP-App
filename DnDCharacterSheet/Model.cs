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
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<CharacterWeapon> CharacterWeapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var databaseFile = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Data", "DnDCharacterSheet.db");
            optionsBuilder.UseSqlite($"Data Source={databaseFile}");
        }

    }

    [Table("characters")]
    public class Character
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("strength")]
        public int Strength { get; set; }
        [Column("strengthModifier")]
        public int StrengthModifier { get; set; }
        [Column("dexterity")]
        public int Dexterity { get; set; }
        [Column("dexterityModifier")]
        public int DexterityModifier { get; set; }
        [Column("constitution")]
        public int Constitution { get; set; }
        [Column("constitutionModifier")]
        public int ConstitutionModifier { get; set; }
        [Column("intelligence")]
        public int Intelligence { get; set; }
        [Column("intelligenceModifier")]
        public int IntelligenceModifier { get; set; }
        [Column("wisdom")]
        public int Wisdom { get; set; }
        [Column("wisdomModifier")]
        public int WisdomModifier { get; set; }
        [Column("charisma")]
        public int Charisma { get; set; }
        [Column("charismaModifier")]
        public int CharismaModifier { get; set; }
        [Column("armorClass")]
        public int ArmorClass { get; set; }
        [Column("speed")]
        public int Speed { get; set; }
        [Column("currentHitPoints")]
        public int CurrentHitPoints { get; set; }
        [Column("temporaryHitPoints")]
        public int TemporaryHitPoints { get; set; }
        [Column("maxHitPoints")]
        public int MaxHitPoints { get; set; }
        [Column("platinum")]
        public int Platinum { get; set; }
        [Column("gold")]
        public int Gold { get; set; }
        [Column("electrum")]
        public int Electrum { get; set; }
        [Column("silver")]
        public int Silver { get; set; }
        [Column("copper")]
        public int Copper { get; set; }
        [Column("xp")]
        public int ExperiencePoints { get; set; }
        [Column("proficiencyBonus")]
        public int ProficiencyBonus { get; set; }
    }
}
