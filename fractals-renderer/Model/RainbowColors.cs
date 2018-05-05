using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace fractals_renderer.Model
{
    static class RainbowColors
    {
        public static Color[] colors;

        static RainbowColors()
        {
            colors = new Color[361];
            colors[360] = Colors.LightPink;
            for (int i = 0; i < 360; i++)
            {
                Rgb color = new Hsb(i, 1, 1).To<Rgb>();
                colors[i] = Color.FromRgb((byte)color.R, (byte)color.G, (byte)color.B);
            }
        }
    }
}
