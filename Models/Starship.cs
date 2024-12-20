namespace StarshipProject.Models;
public class Starship
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public string? StarshipClass { get; set; }
    public long? CostInCredits { get; set; }
    public string? Length { get; set; }
    public string? MaxAtmospheringSpeed { get; set; }
    public int? Crew { get; set; }
    public string? Passengers { get; set; }
    public string? CargoCapacity { get; set; }
    public string? Consumables { get; set; }
    public string? HyperdriveRating { get; set; }
    public string? MGLT { get; set; }
}

