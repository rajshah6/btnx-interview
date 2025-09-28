using System.ComponentModel.DataAnnotations;

namespace ProfileBlazarApp.Models;

public class Person
{
    public int Id { get; set; } = 0;
    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Email { get; set; } = "";

    public string? Phone { get; set; }
}
