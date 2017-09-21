using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheet.Models
{
    [Table("characterWeapons")]
    public class CharacterWeapon
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("characterId")]
        [Column("characterId")]
        public int CharacterId { get; set; }
        [ForeignKey("weaponId")]
        [Column("weaponId")]
        public int WeaponId { get; set; }
    }
}
