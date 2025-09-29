using ProfileWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register ProfileRepository as a singleton to simulate database persistence
builder.Services.AddSingleton<IProfileRepository, ProfileRepository>();

// Add CORS policy to allow the Blazor client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        builder =>
        {
            builder.WithOrigins("http://localhost:5043")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

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

// API endpoints
app.MapGet("/api/profile", async (IProfileRepository repository) =>
{
    var profile = await repository.GetProfileAsync();
    return profile != null ? Results.Ok(profile) : Results.NotFound();
});

app.MapPost("/api/profile", async (ProfileWebApi.Models.Profile updatedProfile, IProfileRepository repository) =>
{
    var profile = await repository.UpdateProfileAsync(updatedProfile);
    return Results.Ok(profile);
});

app.Run();
