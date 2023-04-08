double neededXp = double.Parse(Console.ReadLine());
int battlesCnt = int.Parse(Console.ReadLine());

double gainedXp = 0;
int thirdDayCnt = 0;
int fifthDayCnt = 0;
int fifteenthDayCnt = 0;
int doneBattles = 0;

for (int i = 0; i < battlesCnt; i++)
{
    double daily = double.Parse(Console.ReadLine());
    thirdDayCnt++;
    fifthDayCnt++;
    fifteenthDayCnt++;
    doneBattles++;


    gainedXp = gainedXp + daily;

    if (thirdDayCnt == 3)
    {
        if (fifthDayCnt == 5)
        {
            if (fifteenthDayCnt == 15)
            {
                gainedXp = gainedXp + daily * 0.15;
                gainedXp = gainedXp - daily * 0.1;
                gainedXp = gainedXp + daily * 0.05;
                
                thirdDayCnt = 0;
                fifthDayCnt = 0;
                fifteenthDayCnt = 0;
            }
            gainedXp = gainedXp + daily * 0.15;
            gainedXp = gainedXp - daily * 0.1;
            thirdDayCnt = 0;
            fifthDayCnt = 0;
        }
        gainedXp = gainedXp + daily * 0.15;
        thirdDayCnt = 0;
        if (gainedXp >= neededXp)
        {
            break;
        }
    }
    else if (fifthDayCnt == 5)
    {
        if (fifteenthDayCnt == 15)
        {
            gainedXp = gainedXp - daily * 0.1;
            gainedXp = gainedXp + daily * 0.05;
            fifthDayCnt = 0;
            fifteenthDayCnt = 0;
        }
        gainedXp = gainedXp - daily * 0.1;
        fifthDayCnt = 0;
        if (gainedXp >= neededXp)
        {
            break;
        }
    }
    else if (fifteenthDayCnt == 15)
    {
        gainedXp = gainedXp + daily * 0.05;
        fifteenthDayCnt = 0;
        if (gainedXp >= neededXp)
        {
            break;
        }
    }
    if (gainedXp >= neededXp)
    {
        break;
    }

}
if (gainedXp >= neededXp)
{
    Console.WriteLine($"Player successfully collected his needed experience for {doneBattles} battles.");
}
else
{
    double t = neededXp - gainedXp;
    Console.WriteLine($"Player was not able to collect the needed experience, {t:f2} more needed.");
}