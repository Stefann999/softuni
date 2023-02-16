using System.Numerics;

int daysOfPlunder = int.Parse(Console.ReadLine());
int dailyPlunder = int.Parse(Console.ReadLine());
double expectedPlunder = double.Parse(Console.ReadLine());

int thirdDayCnt = 0;
int fifthDayCnt = 0;
double gainedPlunder = 0;
double dbDaily = (double)dailyPlunder;

for (int i = 0; i < daysOfPlunder; i++)
{
    gainedPlunder = gainedPlunder + dailyPlunder;
	thirdDayCnt++;
	fifthDayCnt++;

	if (thirdDayCnt == 3)
	{
		if (fifthDayCnt == 5)
		{
			gainedPlunder = gainedPlunder + dbDaily * 0.5;
			gainedPlunder = gainedPlunder - gainedPlunder * 0.3;
			thirdDayCnt = 0;
			fifthDayCnt = 0;
		}
		else
		{
			gainedPlunder = gainedPlunder + dbDaily * 0.5;
			thirdDayCnt = 0;
		}
	}
	else if (fifthDayCnt == 5)
	{
		gainedPlunder = gainedPlunder - gainedPlunder * 0.3;
		fifthDayCnt = 0;
	}
}
if (gainedPlunder >= expectedPlunder)
{
	Console.WriteLine($"Ahoy! {gainedPlunder:f2} plunder gained.");
}
else
{
	double percentComplete = 100 * gainedPlunder / expectedPlunder;
    Console.WriteLine($"Collected only {percentComplete:f2}% of the plunder.");
}