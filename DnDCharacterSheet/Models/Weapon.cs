﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheet.Models
{
    [Table("weapons")]
    public class Weapon
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("cost")]
        public int Cost { get; set; }
        [Column("costType")]
        public string CostType { get; set; }
        [Column("damage")]
        public string Damage { get; set; }
        [Column("damageType")]
        public string DamageType { get; set; }
        [Column("weight")]
        public float Weight { get; set; }
        [Column("weaponTypeId")]
        public WeaponType WeaponType { get; set; }
        public virtual ICollection<CharacterWeapon> Characters { get; set; }
    }
}
