using FirmaManager.Common;
using System;
using System.Globalization;
using System.Windows.Data;

namespace FirmaManager.Converter
{
    public class ConnectionStatusTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Constants.CONNECTIONSTATUS_SUCCESS : Constants.CONNECTIONSTATUS_FAIL;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}