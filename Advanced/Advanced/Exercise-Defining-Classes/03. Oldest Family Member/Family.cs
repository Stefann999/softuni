using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses;

public class Family
{
    private List<Person> people;

    public Family()
    {
        people = new();
    }

    public List<Person> People { get; set; }
    

    public void AddMember(Person person)
    {
        people.Add(person);
    }

    public Person GetOldestMember()
    {
        return people.MaxBy(p => p.Age);
    }
}