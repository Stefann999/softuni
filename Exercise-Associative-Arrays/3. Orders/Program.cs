Dictionary<string, double[]> orders = new Dictionary<string, double[]>();

string input = Console.ReadLine();

while (input != "buy")
{
    string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string item = cmdArgs[0];
    double price = double.Parse(cmdArgs[1]);
    double quantity = double.Parse(cmdArgs[2]);

    if (!orders.ContainsKey(item))
    {
        orders[item] = new double[] { price, quantity };
    }
    else
    {
        orders[item][0] = price;
        orders[item][1] += quantity;
    }

    input = Console.ReadLine();
}

foreach (var item in orders)
{
    double totalPrice = item.Value[0] * item.Value[1];
    Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
}
