using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
    public class Material
    {
        public Color_dbl color;
        public Material(Color_dbl c) { color = c; }
        public Material(int r, int g, int b)
        {
            color = new Color_dbl(r, g, b);
        }
    }
}
