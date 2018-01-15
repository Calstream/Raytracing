using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Raytracing
{
    class Scene
    {
        Color backColor;
        double ambience;
        List<IObject> objects;
        Vector eye;

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
        public Scene Test()
        {
            Scene res = new Scene();
            res.eye = new Vector(10, 5, 10);
            res.backColor = Color.Gray;
            res.ambience = 0.2;
            Vector t = new Vector(0, 5, 0);
            Material m = new Material(Color.Gold);
            Sphere s = new Sphere(t,5,m);
            res.objects.Add(s);
            return res;
        }
    }
}
