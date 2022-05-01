using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LaserGame_V2_2
{
    public class ColorGun
    {

        public string colorcmd;

        public ColorGun(string colorcmd)
        {
            this.colorcmd = colorcmd;
        }
        public ColorGun(RGB rgb)
        {
            colorcmd = getColorStringCmd(rgb);
        }
        public ColorGun(MainService main)
        {
            colorcmd = main.config.NoColorCmd;
        }

        public string getColorStringCmd(RGB _color, double _lightness = 1)
        {
            string playerColorCmd = "A";
            playerColorCmd += ((byte)(_color.R * _lightness)).ToString().PadLeft(3, '0');
            playerColorCmd += ((byte)(_color.G * _lightness)).ToString().PadLeft(3, '0');
            playerColorCmd += ((byte)(_color.B * _lightness)).ToString().PadLeft(3, '0');
            playerColorCmd += "z";
            return playerColorCmd;
        }

        public RGB getColorRGB(string _colorstr)
        {
            if(_colorstr != null) { 
                try
                {
                    char C0 = _colorstr.ToCharArray()[0];
                    char C10 = _colorstr.ToCharArray()[10];
                    if (C0 == 'A')
                    {
                        int R, G, B = 0;
                        char C1 = _colorstr.ToCharArray()[1];
                        char C2 = _colorstr.ToCharArray()[2];
                        char C3 = _colorstr.ToCharArray()[3];
                        char C4 = _colorstr.ToCharArray()[4];
                        char C5 = _colorstr.ToCharArray()[5];
                        char C6 = _colorstr.ToCharArray()[6];
                        char C7 = _colorstr.ToCharArray()[7];
                        char C8 = _colorstr.ToCharArray()[8];
                        char C9 = _colorstr.ToCharArray()[9];
                        R = (C1 - '0') * 100 + (C2 - '0') * 10 + (C3 - '0');
                        G = (C4 - '0') * 100 + (C5 - '0') * 10 + (C6 - '0');
                        B = (C7 - '0') * 100 + (C8 - '0') * 10 + (C9 - '0');

                        return new RGB((byte)R, (byte)G, (byte)B);
                    }
                }
                catch { }
            }
            return new RGB(0, 0, 0);
        }

        public SolidColorBrush getColorBrush(string _colorcmd, double _lightness = 1)
        {
            try {
                RGB v3 = getColorRGB(_colorcmd);
                var brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                    255, (byte)(v3.R * _lightness), (byte)(v3.G * _lightness), (byte)(v3.B * _lightness) ));
                return brush;
            }
            catch
            {
                return new SolidColorBrush();
            }
        }

        public string getColorStringCmd(double _lightness = 1)
        {
            return getColorStringCmd(getColorRGB(colorcmd), _lightness);
        }

        public string getColorStringCmd()
        {
            return colorcmd;
        }
        public RGB getColorRGB()
        {
            return getColorRGB(colorcmd);
        }
    }

    public class RGB
    {
        public byte R = 0;
        public byte G = 0;
        public byte B = 0;
        public RGB(byte r, byte g, byte b)
        {
            R = r; G = g; B = b;
        }
    }
}
