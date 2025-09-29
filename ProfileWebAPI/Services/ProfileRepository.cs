using ProfileWebApi.Models;

namespace ProfileWebApi.Services;

public interface IProfileRepository
{
    Task<Profile?> GetProfileAsync();
    Task<Profile> UpdateProfileAsync(Profile newProfile);
}

public class ProfileRepository : IProfileRepository
{
    // Simulate a database with in-memory storage
    private static Profile _profile = new Profile
    {
        Id = 1,
        FirstName = "John", // sample data
        LastName = "Doe",
        Email = "john.doe@example.com",
        PhoneNumber = "123-456-7890"
    };

    public async Task<Profile?> GetProfileAsync()
    {
        // Simulate async database operation with a small delay
        await Task.Delay(10);
        return _profile;
    }

    public async Task<Profile> UpdateProfileAsync(Profile newProfile)
    {
        // Simulate async database operation with a small delay
        await Task.Delay(10);

        // Update the stored profile
        _profile.FirstName = newProfile.FirstName;
        _profile.LastName = newProfile.LastName;
        _profile.Email = newProfile.Email;
        _profile.PhoneNumber = newProfile.PhoneNumber;

        return _profile;
    }
}
