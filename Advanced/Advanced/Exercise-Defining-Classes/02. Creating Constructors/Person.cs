namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            Name = "No name";
            Age = 1;

        }

        public Person(int receivedAge) : this()
        {
            Age = receivedAge;

        }

        public Person(string receivedName, int receivedAge) : this(receivedAge)
        {
            Name = receivedName;
        }


        public string Name { get; set; }
        public int Age { get; set; }
    }
}