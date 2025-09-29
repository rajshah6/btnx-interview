using ProfileWebApi.Models;

namespace ProfileWebApi.Services;

public interface IProfileRepository
{
    Task<Profile?> GetProfileAsync();
    Task<Profile> UpdateProfileAsync(Profile profile);
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

    public async Task<Profile> UpdateProfileAsync(Profile updatedProfile)
    {
        // Simulate async database operation with a small delay
        await Task.Delay(10);

        // Update the stored profile
        _profile.Id = updatedProfile.Id;
        _profile.FirstName = updatedProfile.FirstName;
        _profile.LastName = updatedProfile.LastName;
        _profile.Email = updatedProfile.Email;
        _profile.PhoneNumber = updatedProfile.PhoneNumber;

        return _profile;
    }
}
