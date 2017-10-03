using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DnDCharacterSheet.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArmorClass = table.Column<int>(nullable: false),
                    ArmorId = table.Column<int>(nullable: true),
                    Charisma = table.Column<int>(nullable: false),
                    CharismaModifier = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    ConstitutionModifier = table.Column<int>(nullable: false),
                    Copper = table.Column<int>(nullable: false),
                    CurrentHitPoints = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    DexterityModifier = table.Column<int>(nullable: false),
                    Electrum = table.Column<int>(nullable: false),
                    ExperiencePoints = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    IntelligenceModifier = table.Column<int>(nullable: false),
                    MaxHitPoints = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Platinum = table.Column<int>(nullable: false),
                    ProficiencyBonus = table.Column<int>(nullable: false),
                    Silver = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    StrengthModifier = table.Column<int>(nullable: false),
                    TemporaryHitPoints = table.Column<int>(nullable: false),
                    WeaponId = table.Column<int>(nullable: true),
                    Wisdom = table.Column<int>(nullable: false),
                    WisdomModifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    ArmorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    CostType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Weight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.ArmorId);
                    table.ForeignKey(
                        name: "FK_Armor_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    CostType = table.Column<string>(nullable: true),
                    Damage = table.Column<string>(nullable: true),
                    DamageType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    WeaponType = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponId);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armor_CharacterId",
                table: "Armor",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArmorId",
                table: "Characters",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WeaponId",
                table: "Characters",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_ArmorId",
                table: "Characters",
                column: "ArmorId",
                principalTable: "Armor",
                principalColumn: "ArmorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Weapons_WeaponId",
                table: "Characters",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "WeaponId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armor_Characters_CharacterId",
                table: "Armor");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
