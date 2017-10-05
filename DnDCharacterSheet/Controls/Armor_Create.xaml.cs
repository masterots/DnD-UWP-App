using DnDCharacterSheet.Enums;
using DnDCharacterSheet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DnDCharacterSheet.Controls
{
    public sealed partial class Armor_Create : UserControl
    {
        public Armor_Create()
        {
            this.InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new DnDCharacterSheetContext())
            {
                ArmorList.ItemsSource = db.Armor.ToList();
            }
        }

        private bool Is_Assigned_To_Character()
        {
            //RadioButton rb = sender as RadioButton;

            using (var db = new DnDCharacterSheetContext())
            {

            }

            return true;
        }

        private void Add_Armor_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DnDCharacterSheetContext())
            {
                var armor = new Armor
                {
                    Name = ArmorName.Text,
                    Cost = Int32.Parse(ArmorCost.Text),
                    CostType = (CostType)ArmorMoneyType.SelectedValue,
                    Weight = float.Parse(ArmorWeight.Text),
                    Note = ArmorNote.Text
                };

                db.Armor.Add(armor);
                db.SaveChanges();

                ArmorList.ItemsSource = db.Armor.ToList();
            }
        }

        private void Assign_Armor(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            using (var db = new DnDCharacterSheetContext())
            {
                var allArmor = db.Armor;
                var selectedArmor = allArmor.Where(a => a.Name == rb.Tag.ToString()).First();
                var character = db.Characters.Include(c => c.Armor).First();

                foreach (Armor armor in allArmor)
                {
                    character.Armor.Remove(armor);
                }

                character.Armor.Add(selectedArmor);
                db.SaveChanges();
            }
        }
    }
}
