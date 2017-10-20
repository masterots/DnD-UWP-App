using System.ComponentModel.DataAnnotations;

namespace DnDCharacterSheet.Enums
{
    public enum WeaponPropertyType
    {
        [Display(Description = "Light")]
        Light,
        [Display(Description = "Heavy")]
        Heavy,
        [Display(Description = "Reach")]
        Reach,
        [Display(Description = "Special")]
        Special,
        [Display(Description = "Finesse")]
        Finesse,
        [Display(Description = "Two-handed")]
        TwoHanded,
        [Display(Description = "Loading")]
        Loading,
        [Display(Description = "Thrown (range 5/15)")]
        Thrown_Range_5_15,
        [Display(Description = "Thrown (range 20/60)")]
        Thrown_Range_20_60,
        [Display(Description = "Thrown (range 30/120)")]
        Thrown_Range_30_120,
        [Display(Description = "Ammunition (range 25/100)")]
        Ammunition_Range_25_100,
        [Display(Description = "Ammunition (range 30/120)")]
        Ammunition_Range_30_120,
        [Display(Description = "Ammunition (range 80/320)")]
        Ammunition_Range_80_320,
        [Display(Description = "Ammunition (range 100/400)")]
        Ammunition_Range_100_400,
        [Display(Description = "Ammunition (range 150/600)")]
        Ammunition_Range_150_600,
        [Display(Description = "Versatile 1d8")]
        Versatile_1d8,
        [Display(Description = "Versatile 1d10")]
        Versatile_1d10
    }
}
