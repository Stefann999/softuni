namespace Speed_Racing;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car();

            car.Model = info[0];
            car.FuelAmount = double.Parse(info[1]);
            car.FuelConsumptionPerKilometer = double.Parse(info[2]);
            
            cars.Add(car.Model, car);

        }
        string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        while (cmdArgs[0] != "End")
        {
            double distance = double.Parse(cmdArgs[2]);

            Car currCar = cars[cmdArgs[1]];

            currCar.Drive(distance);

            cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        foreach (var car in cars.Values)
        {
            Console.WriteLine($"{ car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        }

    }
}