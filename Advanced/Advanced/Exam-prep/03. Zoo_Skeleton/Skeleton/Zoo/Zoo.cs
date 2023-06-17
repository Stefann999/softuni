using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals{ get; set; }


        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Animals.Count == this.Capacity)
            {
                return "The zoo is full.";
            }
            else
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }

        public int RemoveAnimals(string species) => this.Animals.RemoveAll(x => x.Species == species);

        public List<Animal> GetAnimalsByDiet(string diet) => this.Animals.Where(x => x.Diet == diet).ToList();

        public Animal GetAnimalByWeight(double weight) => this.Animals.FirstOrDefault(x => x.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> animals = Animals.FindAll(a => a.Length >= minimumLength && a.Length <= maximumLength);
            return $"There are {animals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
