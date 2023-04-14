using PokemonTrainer;

string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, Trainers> dictionary = new Dictionary<string, Trainers>();
List<Trainers> trainersList = new List<Trainers>();


while (info[0] != "Tournament")
{
    Trainers trainer = new Trainers();
    Pokemon pokemon = new Pokemon();

	if (!dictionary.ContainsKey(info[0]))
	{
        dictionary.Add(info[0], trainer);
        trainersList.Add(trainer);
	}
    else
    {
        trainer = dictionary[info[0]];
    }

    trainer.Name = info[0];
    pokemon.Name = info[1];
    pokemon.Element = info[2];
    pokemon.Health = int.Parse(info[3]);
    trainer.Pokemons.Add(pokemon);

    info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
}

string element  = Console.ReadLine();

while (element != "End")
{
    foreach (var trainer in trainersList)
    {
        trainer.CheckPokemon(element);
    }

    element = Console.ReadLine();
}

foreach (var trainer in trainersList.OrderByDescending(x => x.NumberOfBadges).ToList())
{
    Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
}