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

        public CharacterOverview_Edit()
        {
            this.InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            MaxHeight = Window.Current.Bounds.Height;

            using (var db = new DnDCharacterSheetContext())
            {
                var character = db.Characters.Include(c => c.Armor).FirstOrDefault();
                CurrentCharacter = character;

                CharacterOverview_Edit_UserControl.DataContext = character;
            }
        }

        private void Save_Character_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCharacter != null)
            {
                UpdateCharacter();
            }
            else
            {
                CreateCharacter();
            }
        }

        private int GetInt(string input)
        {
            int output;
            output = Int32.TryParse(input, out output) ? output : 0;
            return output;
        }

        private void CreateCharacter()
        {
            using (var db = new DnDCharacterSheetContext())
            {
                var character = new Character { 
                    Name = NewCharacter_Name.Text,
                    Strength = GetInt(NewCharacter_Strength.Text),
                    StrengthModifier = GetInt(NewCharacter_StrengthModifier.Text),
                    Dexterity = GetInt(NewCharacter_Dexterity.Text),
                    DexterityModifier = GetInt(NewCharacter_DexterityModifier.Text),
                    Constitution = GetInt(NewCharacter_Constitution.Text),
                    ConstitutionModifier = GetInt(NewCharacter_ConstitutionModifier.Text),
                    Intelligence = GetInt(NewCharacter_Intelligence.Text),
                    IntelligenceModifier = GetInt(NewCharacter_IntelligenceModifier.Text),
                    Wisdom = GetInt(NewCharacter_Wisdom.Text),
                    WisdomModifier = GetInt(NewCharacter_WisdomModifier.Text),
                    Charisma = GetInt(NewCharacter_Charisma.Text),
                    CharismaModifier = GetInt(NewCharacter_CharismaModifier.Text),
                    ArmorClass = GetInt(NewCharacter_ArmorClass.Text),
                    Speed = GetInt(NewCharacter_Speed.Text),
                    CurrentHitPoints = GetInt(NewCharacter_CurrentHitPoints.Text),
                    TemporaryHitPoints = GetInt(NewCharacter_TemporaryHitPoints.Text),
                    MaxHitPoints = GetInt(NewCharacter_MaxHitPoints.Text),
                    Platinum = GetInt(NewCharacter_Platinum.Text),
                    Gold = GetInt(NewCharacter_Gold.Text),
                    Electrum = GetInt(NewCharacter_Electrum.Text),
                    Silver = GetInt(NewCharacter_Silver.Text),
                    Copper = GetInt(NewCharacter_Copper.Text),
                    ExperiencePoints = GetInt(NewCharacter_ExperiencePoints.Text),
                    ProficiencyBonus = GetInt(NewCharacter_ProficiencyBonus.Text),
                };

                db.Characters.Add(character);
                db.SaveChanges();

                CurrentCharacter = db.Characters.FirstOrDefault();
                CharacterOverview_Edit_UserControl.DataContext = CurrentCharacter;
            }
        }

        private void UpdateCharacter()
        {
            using (var db = new DnDCharacterSheetContext())
            {
                CurrentCharacter.Name = NewCharacter_Name.Text;
                CurrentCharacter.Strength = GetInt(NewCharacter_Strength.Text);
                CurrentCharacter.StrengthModifier = GetInt(NewCharacter_StrengthModifier.Text);
                CurrentCharacter.Dexterity = GetInt(NewCharacter_Dexterity.Text);
                CurrentCharacter.DexterityModifier = GetInt(NewCharacter_DexterityModifier.Text);
                CurrentCharacter.Constitution = GetInt(NewCharacter_Constitution.Text);
                CurrentCharacter.ConstitutionModifier = GetInt(NewCharacter_ConstitutionModifier.Text);
                CurrentCharacter.Intelligence = GetInt(NewCharacter_Intelligence.Text);
                CurrentCharacter.IntelligenceModifier = GetInt(NewCharacter_IntelligenceModifier.Text);
                CurrentCharacter.Wisdom = GetInt(NewCharacter_Wisdom.Text);
                CurrentCharacter.WisdomModifier = GetInt(NewCharacter_WisdomModifier.Text);
                CurrentCharacter.Charisma = GetInt(NewCharacter_Charisma.Text);
                CurrentCharacter.CharismaModifier = GetInt(NewCharacter_CharismaModifier.Text);
                CurrentCharacter.ArmorClass = GetInt(NewCharacter_ArmorClass.Text);
                CurrentCharacter.Speed = GetInt(NewCharacter_Speed.Text);
                CurrentCharacter.CurrentHitPoints = GetInt(NewCharacter_CurrentHitPoints.Text);
                CurrentCharacter.TemporaryHitPoints = GetInt(NewCharacter_TemporaryHitPoints.Text);
                CurrentCharacter.MaxHitPoints = GetInt(NewCharacter_MaxHitPoints.Text);
                CurrentCharacter.Platinum = GetInt(NewCharacter_Platinum.Text);
                CurrentCharacter.Gold = GetInt(NewCharacter_Gold.Text);
                CurrentCharacter.Electrum = GetInt(NewCharacter_Electrum.Text);
                CurrentCharacter.Silver = GetInt(NewCharacter_Silver.Text);
                CurrentCharacter.Copper = GetInt(NewCharacter_Copper.Text);
                CurrentCharacter.ExperiencePoints = GetInt(NewCharacter_ExperiencePoints.Text);
                CurrentCharacter.ProficiencyBonus = GetInt(NewCharacter_ProficiencyBonus.Text);

                db.Characters.Update(CurrentCharacter);
                db.SaveChanges();

                CurrentCharacter = db.Characters.FirstOrDefault();
                CharacterOverview_Edit_UserControl.DataContext = CurrentCharacter;
            }
        }
    }
}
