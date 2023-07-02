namespace _01.ClassBoxData.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
           private get => length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }

                length = value;
            }
        }
        public double Width
        {
           private get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }
                width  = value;
            }
        }
        public double Height
        {
           private get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }
                height = value;
            }
        }


        public double SurfaceArea() => 2 * Length * Width + LateralSurfaceArea();

        public double LateralSurfaceArea() => 2 * Length * Height + 2 * Width * Height;
        
        public double Volume() => Length * Width * Height;


    }
}
