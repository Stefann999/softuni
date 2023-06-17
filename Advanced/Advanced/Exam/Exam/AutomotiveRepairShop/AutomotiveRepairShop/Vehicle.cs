namespace AutomotiveRepairShop
{
    public class Vehicle
    {

        public Vehicle(string vin, int mileage, string damage)
        {
            this.VIN = vin;
            this.Mileage = mileage;
            this.Damage = damage;
        }


        public string VIN { get; set; }
        public int Mileage  { get; set; }
        public string Damage{ get; set; }

        public override string ToString()
        {
            return $"Damage: {Damage}, Vehicle: {VIN} ({Mileage} km)";
        }
    }
}
