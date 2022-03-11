using SimpleChat.DataModel;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SimpleChat.Converters
{
    public class TextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                ChatType chatType = (ChatType) value;

                if (chatType == ChatType.Text)
                    return true;
                else
                    return false;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                ChatType chatType = (ChatType)value;

                if (chatType == ChatType.Image)
                    return true;
                else
                    return false;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class AudioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                ChatType chatType = (ChatType)value;

                if (chatType == ChatType.Audio)
                    return true;
                else
                    return false;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
