using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SimpleChat.Converters
{
    internal static class Converter
    {
        public static object convert(object value, object Object1, object Object2)
        {
            if (value != null)
            {
                bool isReceived = (bool)value;

                if (isReceived)
                    return Object1;
                else
                    return Object2;
            }

            return null;
        }
    }
    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter.convert(value, new Thickness(10, 10, 50, 10), new Thickness(50, 10, 10, 10));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter.convert(value, Color.White, Color.LightGreen);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
