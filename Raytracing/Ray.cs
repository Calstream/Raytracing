using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
    public class Ray
    {
        public Vector Position;
        public Vector Direction;

        public Ray(Vector pos, Vector dir)
        {
            Position = pos;
            Direction = dir;
        }
    }
}
