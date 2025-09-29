var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy to allow the Blazor client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        builder =>
        {
            builder.WithOrigins("http://localhost:5043") // Replace with your Blazor client URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// In-memory storage for profile (for simplicity)
var profile = new ProfileWebApi.Models.Profile
{
    Id = 1,
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@example.com",
    PhoneNumber = "123-456-7890"
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy
app.UseCors("AllowBlazorClient");

// Minimal API endpoints
app.MapGet("/api/profile", () =>
{
    return Results.Ok(profile);
});

app.MapPost("/api/profile", (ProfileWebApi.Models.Profile updatedProfile) =>
{
    profile.FirstName = updatedProfile.FirstName;
    profile.LastName = updatedProfile.LastName;
    profile.Email = updatedProfile.Email;
    profile.PhoneNumber = updatedProfile.PhoneNumber;
    return Results.Ok(profile);
});

app.Run();
