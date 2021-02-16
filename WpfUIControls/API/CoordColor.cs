using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfUIControls.API
{
    public enum CoordColor : int
    {
        Red,
        Green,
        Blue,
        LightGray
    }

    public static class CoordColors
    {
        public static Brush LightGray = new SolidColorBrush(Color.FromArgb(255, 216, 216, 216));
        public static Brush Red = new SolidColorBrush(Color.FromArgb(255, 203, 38, 0));
        public static Brush Green = new SolidColorBrush(Color.FromArgb(255, 103, 169, 0));
        public static Brush Blue = new SolidColorBrush(Color.FromArgb(255, 44, 126, 238));

        public static void Dispose()
        {
            LightGray = null;
            Red = null;
            Green = null;
            Blue = null;
        }
    }
}
