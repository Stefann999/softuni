using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public List<Fish> Fish { get; set; }


        public int Count { get { return Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Lenght <= 0 || fish.Weight <= 0)
            {
                return "Invaild Fish";
            }
            else if (this.Fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                this.Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            var targetFish = this.Fish.FirstOrDefault(x => x.Weight == weight);
            if (targetFish == null)
            {
                return false;
            }
            this.Fish.Remove(targetFish);
            return true;
        }

        public Fish GetFish(string fishType) => this.Fish.FirstOrDefault(x => x.FishType == fishType);

        public Fish GetBiggestFish() => this.Fish.OrderByDescending(x => x.Weight).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in this.Fish.OrderByDescending(x => x.Lenght))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
