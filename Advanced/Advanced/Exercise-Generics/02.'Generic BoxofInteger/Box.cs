namespace _02._Generic_BoxofInteger
{
    public class Box<T>
    {
        public T BoxValue { get; set; }

        public Box(T a)
        {
            BoxValue = a;
        }

        public override string ToString()
        {
            return $"{BoxValue.GetType()}: {BoxValue}";
        }
    }
}