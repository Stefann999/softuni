using PizzaCalories.Models;

try
{
    string[] pizzaInfo = Console.ReadLine().Split();
    string[] doughInfo = Console.ReadLine().Split();

    string pizzaName = pizzaInfo[1];

    Dough dough = new(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

    Pizza pizza = new(pizzaName, dough);

    string[] toppingsInfo = Console.ReadLine().Split();

    while (toppingsInfo[0] != "END")
    {
        Topping topping = new(toppingsInfo[1], double.Parse(toppingsInfo[2]));
        pizza.AddTopping(topping);
        toppingsInfo = Console.ReadLine().Split();
    }

    Console.WriteLine(pizza);
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
