using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Common
{
    /// <summary>
    /// Implementation of a a pass-through converter usinng <see cref="IMultiValueConverter"/>  
    /// which forks the underlying data value into a Key-Value pair 
    /// and the DisplayMember becomes "Key" and the ValueMember becomes a "Value". 
    /// </summary>
    public class PassThroughConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
