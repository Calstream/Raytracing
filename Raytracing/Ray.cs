using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raytracing
{
    public class Ray
    {
        Vector position;
        Vector direction;

        public Ray(Vector pos, Vector dir)
        {
            position = pos;
            direction = dir;
        }
    }
}
