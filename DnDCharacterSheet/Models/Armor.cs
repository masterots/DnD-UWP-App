using DnDCharacterSheet.Enums;
using System.ComponentModel.DataAnnotations;

namespace DnDCharacterSheet.Models
{
    public class Armor
    {
        [Key]
        public int ArmorId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public CostType CostType { get; set; }
        public float Weight { get; set; }
        public string Note { get; set; }
    }
}