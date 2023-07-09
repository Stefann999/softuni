namespace _01.Vehicles
{
    public class Car : Drivable
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Car(double fuelQuantity, double fuelconsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;

            }
            this.FuelConsumption = fuelconsumption + 0.9;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public double TankCapacity { get => tankCapacity; set => tankCapacity = value; }

        public override string Drive(double distance)
        {
            if (FuelQuantity > distance * FuelConsumption)
            {
                FuelQuantity -= distance * FuelConsumption;
                return $"Car travelled {distance} km";
            }
            else
            {
                return "Car needs refueling";
            }
        }

        public override void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity + quantity > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {quantity} fuel in the tank");
                }
                else
                {
                    FuelQuantity += quantity;
                }
            }
        }
        public override string ToString()
        {
            return $"Car: {FuelQuantity:f2}";
        }
    }
}
