using DnDCharacterSheet.Controls;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DnDCharacterSheet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string CurrentView = "overview";
        private bool IsEditing = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentView = "overview";
            SetActiveContent();
        }

        private void CommandBar_Edit_Click(object sender, RoutedEventArgs e)
        {
            IsEditing = !IsEditing;
            SetActiveContent();
        }

        private void CommandBar_AddArmor_Click(object sender, RoutedEventArgs e)
        {
            CurrentView = "armorCreate";
            SetActiveContent();
        }

        private void CommandBar_AddWeapon_Click(object sender, RoutedEventArgs e)
        {
            CurrentView = "weaponCreate";
            SetActiveContent();
        }

        private void CommandBar_AddSkill_Click(object sender, RoutedEventArgs e)
        {
            CurrentView = "skillCreate";
            SetActiveContent();
        }

        private void CommandBar_AddAdventuringItem_Click(object sender, RoutedEventArgs e)
        {
            CurrentView = "adventuringItemCreate";
            SetActiveContent();
        }

        private void NavPane_Overview_Click(object sender, RoutedEventArgs e)
        {
            CurrentView = "overview";
            SetActiveContent();
        }

        private void NavPane_Actions_Click(object sender, RoutedEventArgs e)
        {
            CurrentView = "actions";
            SetActiveContent();
        }

        private void SetActiveContent()
        {
            switch (CurrentView)
            {
                case "actions":
                    if (!IsEditing)
                    {
                        CurrentContentControl.Content = new Actions();
                        break;
                    }
                    CurrentContentControl.Content = new Actions_Edit();
                    break;
                case "adventuringItemCreate":
                    break;
                case "armorCreate":
                    CurrentContentControl.Content = new Armor_Create();
                    break;
                case "skillCreate":
                    break;
                case "weaponCreate":
                    break;
                default:
                    if (!IsEditing)
                    {
                        CurrentContentControl.Content = new CharacterOverview();
                        break;
                    }
                    CurrentContentControl.Content = new CharacterOverview_Edit();
                    break;
            }
        }
    }
}
