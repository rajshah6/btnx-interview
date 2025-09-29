using System.Net.Http.Json;
using ProfileBlazarApp.Models;

namespace ProfileBlazarApp.Services;

public class ProfileService
{
    private readonly HttpClient _httpClient;

    public ProfileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Profile?> GetProfileAsync()
    {
        try
        {
            var profile = await _httpClient.GetFromJsonAsync<Profile>("api/profile");
            return profile;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching profile: {e.Message}");
            return null;
        }
    }

    public async Task<bool> UpdateProfileAsync(Profile profile)
    {
        try
        {
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