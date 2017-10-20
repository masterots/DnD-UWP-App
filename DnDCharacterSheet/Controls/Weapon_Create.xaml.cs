using DnDCharacterSheet.Enums;
using DnDCharacterSheet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DnDCharacterSheet.Controls
{
    public sealed partial class Weapon_Create : UserControl
    {
        private List<WeaponPropertyType> SelectedWeaponProperties;
        public Weapon_Create()
        {
            this.InitializeComponent();
            SelectedWeaponProperties = new List<WeaponPropertyType>();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            WeaponMoneyType.ItemsSource = Enum.GetValues(typeof(CostType));
            WeaponDamageType.ItemsSource = Enum.GetValues(typeof(DamageType));
            var weaponProperties = Enum.GetValues(typeof(WeaponPropertyType)).Cast<WeaponPropertyType>().ToList();


            using (var db = new DnDCharacterSheetContext())
            {
                //WeaponList.ItemsSource = db.Weapons.ToList();
            }
        }

        private void Add_Weapon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SetWeaponProperty_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb.IsChecked == true)
            {
                WeaponPropertyType property = (WeaponPropertyType)Enum.Parse(typeof(WeaponPropertyType), cb.Name);
                SelectedWeaponProperties.Add(property);
            }
            else
            {
                WeaponPropertyType property = (WeaponPropertyType)Enum.Parse(typeof(WeaponPropertyType), cb.Name);
                SelectedWeaponProperties.Remove(property);
            }
        }
    }
}
