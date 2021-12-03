﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace NumberConverter.UI.Converters
{
    public class RomanNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return value;
            } else
            {
                return "Invalid number";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
