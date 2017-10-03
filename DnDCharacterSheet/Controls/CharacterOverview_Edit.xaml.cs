using DnDCharacterSheet.Models;
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
        public CharacterOverview_Edit()
        {
            this.InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new DnDCharacterSheetContext())
            {
                var character = db.Characters.FirstOrDefault();

                CharacterOverview_Edit_UserControl.DataContext = character;
            }
        }

        private void Save_Character_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DnDCharacterSheetContext())
            {
                var selectedArmor = new List<Armor>();
                selectedArmor.Add((Armor)NewCharacter_Armor.SelectedItem);

                var character = new Character
                {
                    CharacterId = Int32.Parse(NewCharacter_Id.Text),
                    Name = NewCharacter_Name.Text,
                    Strength = Int32.Parse(NewCharacter_Strength.Text),
                    StrengthModifier = Int32.Parse(NewCharacter_StrengthModifier.Text),
                    Dexterity = Int32.Parse(NewCharacter_Dexterity.Text),
                    DexterityModifier = Int32.Parse(NewCharacter_DexterityModifier.Text),
                    Constitution = Int32.Parse(NewCharacter_Constitution.Text),
                    ConstitutionModifier = Int32.Parse(NewCharacter_ConstitutionModifier.Text),
                    Intelligence = Int32.Parse(NewCharacter_Intelligence.Text),
                    IntelligenceModifier = Int32.Parse(NewCharacter_IntelligenceModifier.Text),
                    Wisdom = Int32.Parse(NewCharacter_Wisdom.Text),
                    WisdomModifier = Int32.Parse(NewCharacter_WisdomModifier.Text),
                    Charisma = Int32.Parse(NewCharacter_Charisma.Text),
                    CharismaModifier = Int32.Parse(NewCharacter_CharismaModifier.Text),
                    ArmorClass = Int32.Parse(NewCharacter_ArmorClass.Text),
                    Speed = Int32.Parse(NewCharacter_Speed.Text),
                    CurrentHitPoints = Int32.Parse(NewCharacter_CurrentHitPoints.Text),
                    TemporaryHitPoints = Int32.Parse(NewCharacter_TemporaryHitPoints.Text),
                    MaxHitPoints = Int32.Parse(NewCharacter_MaxHitPoints.Text),
                    Platinum = Int32.Parse(NewCharacter_Platinum.Text),
                    Gold = Int32.Parse(NewCharacter_Gold.Text),
                    Electrum = Int32.Parse(NewCharacter_Electrum.Text),
                    Silver = Int32.Parse(NewCharacter_Silver.Text),
                    Copper = Int32.Parse(NewCharacter_Copper.Text),
                    ExperiencePoints = Int32.Parse(NewCharacter_ExperiencePoints.Text),
                    ProficiencyBonus = Int32.Parse(NewCharacter_ProficiencyBonus.Text),
                    //Armor = selectedArmor
                };

                db.Characters.Update(character);
                db.SaveChanges();

                CharacterOverview_Edit_UserControl.DataContext = db.Characters.FirstOrDefault();
            }
        }
    }
}
