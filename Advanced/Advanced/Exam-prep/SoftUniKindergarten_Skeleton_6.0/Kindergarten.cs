using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Registry = new List<Child>();
        }


        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry{ get; set; }


        public bool AddChild (Child child)
        {
            if (this.Registry.Count < this.Capacity)
            {
                this.Registry.Add (child);
                return true;
            }
            return false;
        }


        public bool RemoveChild (string childFullName)
        {
            Child targetChild = this.Registry.FirstOrDefault(x => x.FirstName + " " +  x.LastName == childFullName);

            bool isRemoved = this.Registry.Remove(targetChild);
            return isRemoved;
        }

        public int ChildrenCount => this.Registry.Count;

        public Child GetChild (string childFullName)
        {
            Child targerChild = this.Registry.FirstOrDefault(x => x.FirstName + " " + x.LastName == childFullName);

            if (targerChild != null)
            {
                return targerChild;
            }
            return null;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {this.Name}:");

            foreach (var child in this.Registry.OrderByDescending(x => x.Age).OrderBy(l => l.LastName).OrderBy(f => f.FirstName))
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
