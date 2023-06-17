using System.Runtime.InteropServices;
using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }


        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }



        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < this.Capacity)
            {
                this.Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle targetVehicle = Vehicles.FirstOrDefault(x => x.VIN == vin);
            if (targetVehicle != null)
            {
                Vehicles.Remove(targetVehicle);
                return true;
            }
            return false;
        }

        public int GetCount() => this.Vehicles.Count;
        
        public Vehicle GetLowestMileage() => this.Vehicles.OrderBy(x => x.Mileage).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");

            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
