using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DnDCharacterSheet;
using DnDCharacterSheet.Enums;

namespace DnDCharacterSheet.Migrations
{
    [DbContext(typeof(DnDCharacterSheetContext))]
    [Migration("20170921020449_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("DnDCharacterSheet.Models.Armor", b =>
                {
                    b.Property<int>("ArmorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CharacterId");

                    b.Property<int>("Cost");

                    b.Property<int>("CostType");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<float>("Weight");

                    b.HasKey("ArmorId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Armor");
                });

            modelBuilder.Entity("DnDCharacterSheet.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArmorClass");

                    b.Property<int?>("ArmorId");

                    b.Property<int>("Charisma");

                    b.Property<int>("CharismaModifier");

                    b.Property<int>("Constitution");

                    b.Property<int>("ConstitutionModifier");

                    b.Property<int>("Copper");

                    b.Property<int>("CurrentHitPoints");

                    b.Property<int>("Dexterity");

                    b.Property<int>("DexterityModifier");

                    b.Property<int>("Electrum");

                    b.Property<int>("ExperiencePoints");

                    b.Property<int>("Gold");

                    b.Property<int>("Intelligence");

                    b.Property<int>("IntelligenceModifier");

                    b.Property<int>("MaxHitPoints");

                    b.Property<string>("Name");

                    b.Property<int>("Platinum");

                    b.Property<int>("ProficiencyBonus");

                    b.Property<int>("Silver");

                    b.Property<int>("Speed");

                    b.Property<int>("Strength");

                    b.Property<int>("StrengthModifier");

                    b.Property<int>("TemporaryHitPoints");

                    b.Property<int?>("WeaponId");

                    b.Property<int>("Wisdom");

                    b.Property<int>("WisdomModifier");

                    b.HasKey("CharacterId");

                    b.HasIndex("ArmorId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DnDCharacterSheet.Models.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CharacterId");

                    b.Property<int>("Cost");

                    b.Property<string>("CostType");

                    b.Property<string>("Damage");

                    b.Property<string>("DamageType");

                    b.Property<string>("Name");

                    b.Property<int>("WeaponType");

                    b.Property<float>("Weight");

                    b.HasKey("WeaponId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("DnDCharacterSheet.Models.Armor", b =>
                {
                    b.HasOne("DnDCharacterSheet.Models.Character")
                        .WithMany("Armor")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("DnDCharacterSheet.Models.Character", b =>
                {
                    b.HasOne("DnDCharacterSheet.Models.Armor")
                        .WithMany("Characters")
                        .HasForeignKey("ArmorId");

                    b.HasOne("DnDCharacterSheet.Models.Weapon")
                        .WithMany("Characters")
                        .HasForeignKey("WeaponId");
                });

            modelBuilder.Entity("DnDCharacterSheet.Models.Weapon", b =>
                {
                    b.HasOne("DnDCharacterSheet.Models.Character")
                        .WithMany("Weapons")
                        .HasForeignKey("CharacterId");
                });
        }
    }
}
