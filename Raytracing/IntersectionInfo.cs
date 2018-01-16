using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
    public class IntersectionInfo
    {
        public bool is_hit; 
        public int hit_count; 
        public IObject hit_object; 
        public Vector pos;
        public Color_dbl Color; 
        public double dist; // hit point to viewport
        public Vector normal; 

        public IntersectionInfo() { }
    }
}
