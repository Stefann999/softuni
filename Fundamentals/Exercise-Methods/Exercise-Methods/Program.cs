using System.Runtime.ExceptionServices;

//int firstNum = int.Parse(Console.ReadLine());
//int secondNum = int.Parse(Console.ReadLine());
//int thirdNum = int.Parse(Console.ReadLine());

//int minNum = int.MaxValue;

//minNumFinding(firstNum, secondNum, thirdNum);

static void minNumFinding();

	for (int i = 0; i <= 2; i++)
	{
		int num = int.Parse(Console.ReadLine());

		if (num < minNum)
		{
			minNum = num;
		}
	}
	Console.WriteLine(minNum);