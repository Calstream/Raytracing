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
            ambience = 0.8;
            Vector t = new Vector(-0.5,0.5,2);
            Material m = new Material(Color.Red);
            Sphere s = new Sphere(t,1.2,m);
            objects = new List<IObject>();
            objects.Add(s);

            Plane p = new Plane(new Vector(0.1, 0.9, -0.5).normalize(), 2, new Material(Color.Gold));
            objects.Add(p);

            Plane p1 = new Plane(new Vector(-0.5, -0.9, 0.1).normalize(), 2, new Material(Color.Azure));
            objects.Add(p1);

            //return res;
        }
    }
}
