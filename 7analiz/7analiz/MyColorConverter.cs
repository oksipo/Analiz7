using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace _7analiz
{
    public class MyColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string temp = (string) value;

            if (temp == "Дуже високою")
            {
                return new SolidColorBrush(Color.FromArgb(200, 255, 50, 50));
            }

            if (temp == "Високою")
            {
                return new SolidColorBrush(Color.FromArgb(200, 255, 100, 100));
            }

            if (temp == "Середньою")
            {
                return new SolidColorBrush(Color.FromArgb(200, 255, 255, 100));
            }

            if (temp == "Низькою")
            {
                return new SolidColorBrush(Color.FromArgb(200, 100, 255, 100));
            }

            if (temp == "Дуже низькою")
            {
                return new SolidColorBrush(Color.FromArgb(200, 50, 255, 50));
            }

            return new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
