using System.Xml.Linq;

Dictionary<string, List<double>> studentInfo = new Dictionary<string, List<double>>();
int rows = int.Parse(Console.ReadLine());

for (int i = 0; i < rows; i++)
{
    string name = Console.ReadLine();
    double grade = double.Parse(Console.ReadLine());

    if (!studentInfo.ContainsKey(name))
    {
        List<double> grades = new List<double>();
        grades.Add(grade);
        studentInfo.Add(name, grades);
    }
    else if (studentInfo.ContainsKey(name))
    {
        List<double> currList = studentInfo[name];
        currList.Add(grade);
        studentInfo[name] = currList;
    }
}


foreach (var student in studentInfo)
{   
    double avgGrade = student.Value.Average();
    if (avgGrade >= 4.50)
    {
     Console.WriteLine($"{student.Key} -> {avgGrade:f2}");
    }
}