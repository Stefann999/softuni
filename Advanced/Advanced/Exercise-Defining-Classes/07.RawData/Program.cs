using RawData;

int n = int.Parse(Console.ReadLine());

List<Car> cars = new();

for (int i = 0; i < n; i++)
{
    string[] info = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    Car car = new(
        info[0],
        int.Parse(info[1]),
        int.Parse(info[2]),
        int.Parse(info[3]),
        info[4],
        double.Parse(info[5]),
        int.Parse(info[6]),
        double.Parse(info[7]),
        int.Parse(info[8]),
        double.Parse(info[9]),
        int.Parse(info[10]),
        double.Parse(info[11]),
        int.Parse(info[12])
        );

    cars.Add(car);
}

string command = Console.ReadLine();

string[] print;

if (command == "fragile")
{
    print = cars
        .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
        .Select(c => c.Model)
        .ToArray();
}
else
{
    print = cars
        .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
        .Select(c => c.Model)
        .ToArray();
}

Console.WriteLine(string.Join(Environment.NewLine, print));