namespace _04.BorderControl.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }


        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
