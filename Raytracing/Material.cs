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
        public Color color;
        public Material(Color c) { color = c; }
        public Material(int r, int g, int b, int a = 255)
        {
            color = Color.FromArgb(a, r, g, b);
        }
    }
}
