using DnDCharacterSheet.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheet.Models
{
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string CostType { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public float Weight { get; set; }
        public WeaponType WeaponType { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
