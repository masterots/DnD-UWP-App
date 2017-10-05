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
    public sealed partial class CharacterOverview_Edit : UserControl
    {
        public Character CurrentCharacter;
        public Armor CurrentCharacterArmor;
        public RadioButton SelectedArmorRadio;

        public CharacterOverview_Edit()
        {
            this.InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            MaxHeight = Window.Current.Bounds.Height;

            using (var db = new DnDCharacterSheetContext())
            {
                var armor = db.Armor.ToList();
                var character = db.Characters.Include(c => c.Armor).FirstOrDefault();
                CurrentCharacter = character;
                CurrentCharacterArmor = character.Armor.FirstOrDefault();

                CharacterOverview_Edit_UserControl.DataContext = character;
                NewCharacter_Armor.ItemsSource = armor;

                //if (CurrentCharacterArmor != null) { 
                //    NewCharacter_Armor.SelectedItem = CurrentCharacterArmor;
                //}
            }
        }

        private void ArmorRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SelectedArmorRadio = sender as RadioButton;
        }

        private void Save_Character_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DnDCharacterSheetContext())
            {
                CurrentCharacter.Name = NewCharacter_Name.Text;
                CurrentCharacter.Strength = Int32.Parse(NewCharacter_Strength.Text);
                CurrentCharacter.StrengthModifier = Int32.Parse(NewCharacter_StrengthModifier.Text);
                CurrentCharacter.Dexterity = Int32.Parse(NewCharacter_Dexterity.Text);
                CurrentCharacter.DexterityModifier = Int32.Parse(NewCharacter_DexterityModifier.Text);
                CurrentCharacter.Constitution = Int32.Parse(NewCharacter_Constitution.Text);
                CurrentCharacter.ConstitutionModifier = Int32.Parse(NewCharacter_ConstitutionModifier.Text);
                CurrentCharacter.Intelligence = Int32.Parse(NewCharacter_Intelligence.Text);
                CurrentCharacter.IntelligenceModifier = Int32.Parse(NewCharacter_IntelligenceModifier.Text);
                CurrentCharacter.Wisdom = Int32.Parse(NewCharacter_Wisdom.Text);
                CurrentCharacter.WisdomModifier = Int32.Parse(NewCharacter_WisdomModifier.Text);
                CurrentCharacter.Charisma = Int32.Parse(NewCharacter_Charisma.Text);
                CurrentCharacter.CharismaModifier = Int32.Parse(NewCharacter_CharismaModifier.Text);
                CurrentCharacter.ArmorClass = Int32.Parse(NewCharacter_ArmorClass.Text);
                CurrentCharacter.Speed = Int32.Parse(NewCharacter_Speed.Text);
                CurrentCharacter.CurrentHitPoints = Int32.Parse(NewCharacter_CurrentHitPoints.Text);
                CurrentCharacter.TemporaryHitPoints = Int32.Parse(NewCharacter_TemporaryHitPoints.Text);
                CurrentCharacter.MaxHitPoints = Int32.Parse(NewCharacter_MaxHitPoints.Text);
                CurrentCharacter.Platinum = Int32.Parse(NewCharacter_Platinum.Text);
                CurrentCharacter.Gold = Int32.Parse(NewCharacter_Gold.Text);
                CurrentCharacter.Electrum = Int32.Parse(NewCharacter_Electrum.Text);
                CurrentCharacter.Silver = Int32.Parse(NewCharacter_Silver.Text);
                CurrentCharacter.Copper = Int32.Parse(NewCharacter_Copper.Text);
                CurrentCharacter.ExperiencePoints = Int32.Parse(NewCharacter_ExperiencePoints.Text);
                CurrentCharacter.ProficiencyBonus = Int32.Parse(NewCharacter_ProficiencyBonus.Text);

                db.Characters.Update(CurrentCharacter);
                db.SaveChanges();

                CurrentCharacter = db.Characters.FirstOrDefault();
                CharacterOverview_Edit_UserControl.DataContext = CurrentCharacter;
            }
        }
    }
}
