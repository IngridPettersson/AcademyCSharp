using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloadingCodeAlong
{
    class Box
    {

        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Volume => Length * Width * Height;

        //Detta är vad som händer bakom kulisserna, propertyn är en getter behind the scenes.
        //public double Volume
        //{
        //    get { return Length * Width * Height; }
        //}

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public static bool LessThan(Box a, Box b)
        {
            return a.Volume < b.Volume;
        }

        //Om metoden bara har en rad kan man skriva den som lambda
        //public static bool LessThan(Box a, Box b) => a.Volume < b.Volume;
        public static bool GreaterThan(Box a, Box b)
        {
            return a.Volume > b.Volume;
        }

        public static bool operator <(Box a, Box b)
        {
            return a.Volume < b.Volume;
        }

        public static bool operator >(Box a, Box b)
        {
            return a.Volume > b.Volume;
        }

        public static bool operator ==(Box a, Box b)
        {
            return a.Volume == b.Volume;
        }

        public static bool operator !=(Box a, Box b)
        {
            return a.Volume != b.Volume;
        }

        public override bool Equals(object obj)
        {
            Box box = null;
            if (obj is Box)
                box = obj as Box;

            return box == this;
        }

        public override int GetHashCode()
        {
            return Length.GetHashCode() + Width.GetHashCode() + Height.GetHashCode();
        }

    }
}
