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
        //public int HitCount; // counts the number of shapes that were hit
        //public IShape Element; // the closest shape that was intersected
        //public Vector Position; // position of intersection
        //public Vector Normal; // normal vector on intesection point 
        public Color Color; // color at intersection
        //public double Distance; // distance from point to screen

        public IntersectionInfo() { }
    }
}
