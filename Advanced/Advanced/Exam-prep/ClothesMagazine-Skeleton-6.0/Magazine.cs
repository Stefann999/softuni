using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Clothes = new();
        }

        public string Type { get; set; }
        public int Capacity{ get; set; }
        public List<Cloth> Clothes { get; set; }


        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < this.Capacity)
            {
               this.Clothes.Add(cloth);
            }
        }
        public bool RemoveCloth(string color)
        {
            Cloth targetCloth = Clothes.FirstOrDefault(x => x.Color == color);
            if (targetCloth != null)
            {
                Clothes.Remove(targetCloth);
                return true;
            }
            return false;
        }

        public Cloth GetSmallestCloth() => this.Clothes.OrderBy(c => c.Size).FirstOrDefault();

        public Cloth GetCloth(string color) => this.Clothes.FirstOrDefault(x => x.Color == color);

        public int GetClothCount() => this.Clothes.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Type} magazine contains:");

            foreach (var item in Clothes.OrderBy(x => x.Size))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
