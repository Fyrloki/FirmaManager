using FirmaManager.Common;
using System;
using System.Globalization;
using System.Windows.Data;

namespace FirmaManager.Converter
{
    public class GenderDesignationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value switch
            {
                Constants.SHORTED_GENDER_FEMALE => Constants.GENDER_FEMALE,
                Constants.SHORTED_GENDER_MALE => Constants.GENDER_MALE,
                _ => string.Empty,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value switch
            {
                Constants.GENDER_FEMALE => Constants.SHORTED_GENDER_FEMALE,
                Constants.GENDER_MALE => Constants.SHORTED_GENDER_MALE,
                _ => string.Empty,
            };
        }
    }
}