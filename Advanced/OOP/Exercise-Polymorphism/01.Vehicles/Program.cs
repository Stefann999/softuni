using _01.Vehicles;

string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


Car car = new(double.Parse(carInfo[1]),double.Parse(carInfo[2]), double.Parse(carInfo[3]));
Truck truck = new(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
Bus bus = new(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (command[0] == "Drive")
    {
        if (command[1] == "Car")
        {
            Console.WriteLine(car.Drive(double.Parse(command[2])));
        }
        else if (command[1] == "Truck")
        {
            Console.WriteLine(truck.Drive(double.Parse(command[2]))); 
        }
        else if (command[1] == "Bus")
        {
            Console.WriteLine(bus.Drive(double.Parse(command[2])));
        }
    }

    else if (command[0] == "DriveEmpty")
    {
        Console.WriteLine(bus.DriveEmpty(double.Parse(command[2])));
    }

    else if (command[0] == "Refuel")
    {
        if (command[1] == "Car")
        {
            car.Refuel(double.Parse(command[2]));
        }
        else if (command[1] == "Truck")
        {
            truck.Refuel(double.Parse(command[2]));
        }
        else if (command[1] == "Bus")
        {
            bus.Refuel(double.Parse(command[2]));
        }
    }
}

Console.WriteLine(car.ToString());
Console.WriteLine(truck.ToString());
Console.WriteLine(bus.ToString());