using ProfileWebAPI.Models;
using ProfileWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PersonStore>();

// Change these to match the Blazor dev ports printed in its console
const string BlazorHttps = "http://localhost:5185";
const string BlazorHttp  = "http://localhost:5185";

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins(BlazorHttps, BlazorHttp)
              .AllowAnyHeader()
              .AllowAnyMethod());
});

PersonStore personStore = new PersonStore();

// sample person
personStore.Upsert(new Person { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "1234567890" });

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();           // CORS middleware
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
