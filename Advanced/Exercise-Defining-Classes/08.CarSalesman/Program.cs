using CarSalesman;

int n = int.Parse(Console.ReadLine());

List<Engine> enginesList = new List<Engine>();
List<Car> carsList = new List<Car>();

for (int i = 0; i < n; i++)
{
    string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

     Engine engine =  CreateEngine(info);

    enginesList.Add(engine);
}

int m = int.Parse(Console.ReadLine());

for (int i = 0; i < m; i++)
{
    string[] carProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    Car car = CreateCar(carProperties, enginesList);

    carsList.Add(car);
}

foreach (var car in carsList)
{
    Console.WriteLine(car.ToString());
}



static Engine CreateEngine(string[] info)
{
    Engine engine = new Engine();

    engine.Model = info[0];
    engine.Power = int.Parse(info[1]);

    if (info.Length > 2)
    {
        int displacement;

        bool isDigit = int.TryParse(info[2], out displacement);

        if (isDigit)
        {
            engine.Displacement = displacement;
        }
        else
        {
            engine.Efficiency = info[2];
        }

        if (info.Length > 3)
        {
            engine.Efficiency = info[3];
        }
    }

    return engine;
}
static Car CreateCar(string[] info, List<Engine> enginesList)
    {
    Engine engine = enginesList.Find(x => x.Model == info[1]);

    Car car = new Car();

    car.Model = info[0];
    car.Engine = engine;

   if (info.Length > 2)
   {
       int weight;

       bool isDigit = int.TryParse(info[2], out weight);

       if (isDigit)
       {
            car.Weight = weight;
       }
       else
       {
           car.Color = info[2];
       }

       if (info.Length > 3)
       {
           car.Color = info[3];
       }
   }
      return car;
   }