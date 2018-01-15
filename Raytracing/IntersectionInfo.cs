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
        public bool IsHit; // indicates if the shape was hit
        public int HitCount; // counts the number of shapes that were hit
        public IObject hit_object; // the closest shape that was intersected
        public Vector Position; // position of intersection
        public Color_dbl Color; // color at intersection
        public double Distance; // distance from point to screen
        public Vector Normal; // normal vector on intesection point 

        public IntersectionInfo() { }
    }
}
