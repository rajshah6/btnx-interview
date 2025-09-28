using System.Net.Http.Json;
using ProfileBlazarApp.Models;

namespace ProfileBlazarApp.Services;

// use HttpClient to deserialize JSON into Person objects
public class PersonApiClient(HttpClient http)
{
    public Task<Person?> GetAsync(int id) =>
        http.GetFromJsonAsync<Person>($"api/people/{id}");

    public async Task CreateAsync(Person p)
    {
        var res = await http.PostAsJsonAsync("api/people", p);
        res.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(Person p)
    {
        var res = await http.PutAsJsonAsync($"api/people/{p.Id}", p);
        res.EnsureSuccessStatusCode();
    }
}
