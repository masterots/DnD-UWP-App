using DnDCharacterSheet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DnDCharacterSheet.Controls
{
    public sealed partial class CharacterOverview : UserControl
    {
        public CharacterOverview()
        {
            this.InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new DnDCharacterSheetContext())
            {
                var characterCount = db.Characters.Count();
                var character = db.Characters.Include(c => c.Armor).FirstOrDefault();

                CharacterOverviewUserControl.DataContext = character;
                if (character != null) { 
                    ArmorList.ItemsSource = character.Armor;
                }
            }
        }
    }
}
