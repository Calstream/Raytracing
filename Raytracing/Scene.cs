using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Raytracing
{
    public class Scene
    {
        public Color backColor;
        public double ambience;
        public List<IObject> objects;
        public List<Light> lights;
        public Vector eye_pos;
        public Vector eye_dir;

        public IntersectionInfo IntersectRay(Ray ray)
        {
            int hitCount = 0;
            IntersectionInfo res = new IntersectionInfo();
            res.Distance = double.MaxValue;
            foreach (IObject o in objects)
            {
                IntersectionInfo i = o.Intersect(ray);
                if (i.IsHit && i.Distance < res.Distance && i.Distance > 0)
                {
                    res = i;
                    hitCount++;
                }
            }
            return res;
        }
        public void SetTest()
        {
            //Scene res = new Scene();
            eye_pos = new Vector(0, 0, -15);
            eye_dir = new Vector(-0.2,0,5);
            backColor = Color.Gray;
            ambience = 0.2;
            Vector t = new Vector(-0.5,0.5,2);
            Material m = new Material(Color.Red);
            Sphere s = new Sphere(t,1.2,m);
            objects = new List<IObject>();
            objects.Add(s);
            //return res;
        }
    }
}
