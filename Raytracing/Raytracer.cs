using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Raytracing
{
    class Raytracer
    {
        void Render(PictureBox p)
        {
            Bitmap b = p.Image as Bitmap;
            for (int x = 0; x < p.Width; ++x)
                for (int y = 0; y < p.Height; ++y)
                {
                    b.SetPixel(x, y, getColor(x, y));
                }
            p.Refresh();
        }

        Color getColor(int x, int y)
        {
            return Color.AliceBlue;
        }

        public void RayTraceScene(Graphics g, Rectangle viewport, Scene scene)
        {
            g.FillRectangle(Brushes.Black, viewport);
            Ray ray = new Ray();
            Color c = CalculateColor(ray, scene);

        }

        public Color CalculateColor(Ray ray, Scene scene)
        {
            IntersectionInfo info = TestIntersection(ray, scene, null);
            if (info.IsHit)
            {
                // execute the actual raytrace algorithm
                Color c = RayTrace(info, ray, scene, 0);
                return c;
            }

            return scene.backColor;
        }


        private Color RayTrace(IntersectionInfo info, Ray ray, Scene scene, int depth)
        {
            // calculate ambient light
            double sa = scene.ambience;
            Color color = Color.FromArgb((int)(info.Color.R * sa), (int)(info.Color.G * sa), (int)(info.Color.B * sa));
            //double shininess = Math.Pow(10, info.Element.Material.Gloss + 1);

            
            return color;
        }


        private IntersectionInfo TestIntersection(Ray ray, Scene scene, IObject exclude)
        {
            int hitcount = 0;
            IntersectionInfo best = new IntersectionInfo();
            best.Distance = double.MaxValue;

            foreach (IObject o in scene.objects)
            {
                if (o == exclude)
                    continue;

                IntersectionInfo info = o.Intersect(ray);
                if (info.IsHit && info.Distance < best.Distance && info.Distance >= 0)
                {
                    best = info;
                    hitcount++;
                }
            }
            best.HitCount = hitcount;
            return best;
        }

    }


}
