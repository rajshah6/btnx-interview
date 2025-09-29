using System.Net.Http.Json;
using ProfileBlazarApp.Models;

namespace ProfileBlazarApp.Services;

public class ProfileAPIClient
{
    private readonly HttpClient _httpClient;

    public ProfileAPIClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Person?> GetProfileAsync()
    {
        try
        {
            // api/profile is the endpoint in the API (ProfileController.cs)
            var profile = await _httpClient.GetFromJsonAsync<Person>("api/profile");
            return profile;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching profile: {e.Message}");
            return null;
        }
    }

    public async Task<bool> UpdateProfileAsync(Person profile)
    {
        try
        {
            // api/profile is the endpoint in the API (ProfileController.cs)
            var response = await _httpClient.PostAsJsonAsync("api/profile", profile); 
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error updating profile: {e.Message}");
            return false;
        }
    }
} 