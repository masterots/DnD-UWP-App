using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterSheet.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DnDCharacterSheet.Utils
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            Enum myEnum = value as Enum;
            if (myEnum == null) return DependencyProperty.UnsetValue;

            return myEnum.Description();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return Enum.ToObject(targetType, value);
        }
    }
}
