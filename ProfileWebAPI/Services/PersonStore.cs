using ProfileWebAPI.Models;

namespace ProfileWebAPI.Services;

// Simulate database in memory to store persons
public class PersonStore
{
    private readonly Dictionary<int, Person> _db = new();

    public bool TryGet(int id, out Person person) => _db.TryGetValue(id, out person!);
    public void Upsert(Person p) => _db[p.Id] = p;
}
