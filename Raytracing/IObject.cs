using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Raytracing
{
    public interface IObject
    {
        Vector Position { get; set; }

        Material Material { get; set; }

        Color Intersect(Ray ray);
    }

    public abstract class BaseObject : IObject
    {
        private Vector position;
        private Material material;

        public Material Material
        {
            get { return material; }
            set { material = value; }
        }

        public Vector Position
        {
            get { return position; }
            set { position = value; }
        }

        public BaseObject()
        {
            position = new Vector(0, 0, 0);
            material = new Material(Color.LightPink);
        }

        public abstract IntersectionInfo Intersect(Ray ray);
    }
}
