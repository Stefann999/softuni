int n = int.Parse(Console.ReadLine());

Dictionary<string, Car> cars
    = new Dictionary<string, Car>();

for (int i = 0; i < n; i++)
{
    string[] carInfo = Console.ReadLine()
        .Split('|', StringSplitOptions.RemoveEmptyEntries);

    string name = carInfo[0];
    int mileage = int.Parse(carInfo[1]);
    int fuel = int.Parse(carInfo[2]);

    Car car = new Car
    {
        Name = name,
        Fuel = fuel,
        Mileage = mileage,
    };

    cars.Add(name, car);
}

string command = Console.ReadLine();

while (command != "Stop")
{
    string[] commandInfo = command
        .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

    string commandName = commandInfo[0];

    if (commandName == "Drive")
    {
        string carName = commandInfo[1];
        int desiredDistance = int.Parse(commandInfo[2]);
        int desiredFuel = int.Parse(commandInfo[3]);

        Car car = cars[carName];

        if (desiredFuel > car.Fuel)
        {
            Console.WriteLine("Not enough fuel to make that ride");
            command = Console.ReadLine();
            continue;
        }

        car.Fuel -= desiredFuel;
        car.Mileage += desiredDistance;

        Console.WriteLine($"{carName} driven for {desiredDistance} kilometers. {desiredFuel} liters of fuel consumed.");

        if (car.Mileage >= 100_000)
        {
            Console.WriteLine($"Time to sell the {carName}!");
            cars.Remove(carName);
        }
    }
    else if (commandName == "Refuel")
    {
        string carName = commandInfo[1];
        int newFuel = int.Parse(commandInfo[2]);

        Car car = cars[carName];

        int acutalFuel = 0;

        if (car.Fuel + newFuel > 75)
        {
            acutalFuel = 75 - car.Fuel;
        }
        else
        {
            acutalFuel = newFuel;
        }

        car.Fuel += acutalFuel;

        Console.WriteLine($"{carName} refueled with {acutalFuel} liters");
    }
    else if (commandName == "Revert")
    {
        string carName = commandInfo[1];
        int km = int.Parse(commandInfo[2]);

        Car car = cars[carName];

        car.Mileage -= km;

        if (car.Mileage < 10_000)
        {
            car.Mileage = 10_000;
        }
        else
        {
            Console.WriteLine($"{carName} mileage decreased by {km} kilometers");
        }
    }

    command = Console.ReadLine();
}

foreach (var (carName, car) in cars)
{
    Console.WriteLine($"{carName} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
}

class Car
{
    public string Name { get; set; }

    public int Mileage { get; set; }

    public int Fuel { get; set; }
}