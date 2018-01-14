using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
    public class Plane : BaseObject
    {
        public Vector normal;

        public Plane(Vector pos, Vector n, Material material)
        {
            Position = pos;
            normal = n;
            Material = material;

        }

        public override IntersectionInfo Intersect(Ray ray)
        {
            /// TODO
            return null;
        }

        public override string ToString()
        {
            /// TODO  
            return "";
        }
    }
}
