namespace Speed_Racing;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKilometer;
    private double travelledDistance;

    public Car()
    {
        travelledDistance = 0;
    }


    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKilometer { get; set; }
    public double TravelledDistance { get; set; }

    public void Drive(double distance)
    {
        if (distance * FuelConsumptionPerKilometer <= FuelAmount)
        {
            FuelAmount -= distance * FuelConsumptionPerKilometer;
            TravelledDistance += distance;
        }

        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }


        
    }
}
