using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using StarshipProject.Models;


public class StarshipSeeder(StarshipContext context, HttpClient httpClient)
{
    private readonly StarshipContext _context = context;
    private readonly HttpClient _httpClient = httpClient;

    public async Task SeedAsync()
    {
        // Check if the database is empty
        if (await _context.Starships.AnyAsync())
            return; // Database is not empty; do nothing

        var url = "https://swapi.dev/api/starships/";
        var starships = new List<Starship>();

        do
        {

            // Fetch data from SWAPI
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
            Console.WriteLine("Failed to retrieve data from SWAPI.");
            return;
            }

        
            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<StarshipResponse>(json);

            // Check if data or data.Results is null
            if (data == null || data.Results == null)
            {
                Console.WriteLine("No data was retrieved from the API.");
                return;
            }

            // Map SWAPI data to Starship entities
            starships.AddRange(data.Results.Select(s => new Starship
            {
                Name = s.Name,
                Model = s.Model,
                Manufacturer = s.Manufacturer,
                StarshipClass = s.StarshipClass,
                // Handle non-numeric CostInCredits
                CostInCredits = long.TryParse(s.CostInCredits, out var cost) ? cost : null,
                Length = s.Length,
                MaxAtmospheringSpeed = s.MaxAtmospheringSpeed,
                // Remove commas in Crew and handle non-numeric values
                Crew = int.TryParse(s.Crew?.Replace(",", ""), out var crew) ? crew : null,
                Passengers = s.Passengers,
                CargoCapacity = s.CargoCapacity,
                Consumables = s.Consumables,
                HyperdriveRating = s.HyperdriveRating,
                MGLT = s.MGLT
            }));

            //Move to next page of data
            url = data.Next;

        } while (!string.IsNullOrEmpty(url));

        // Add to database and save
        await _context.Starships.AddRangeAsync(starships);
        await _context.SaveChangesAsync();
    }

    private class StarshipResponse
    {
        [JsonPropertyName("results")]
        public List<StarshipDto>? Results { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }
    }

    private class StarshipDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("manufacturer")]
        public string? Manufacturer { get; set; }

        [JsonPropertyName("cost_in_credits")]
        public string? CostInCredits { get; set; }

        [JsonPropertyName("length")]
        public string? Length { get; set; }

        [JsonPropertyName("max_atmosphering_speed")]
        public string? MaxAtmospheringSpeed { get; set; }

        [JsonPropertyName("crew")]
        public string? Crew { get; set; }

        [JsonPropertyName("passengers")]
        public string? Passengers { get; set; }

        [JsonPropertyName("cargo_capacity")]
        public string? CargoCapacity { get; set; }

        [JsonPropertyName("consumables")]
        public string? Consumables { get; set; }

        [JsonPropertyName("hyperdrive_rating")]
        public string? HyperdriveRating { get; set; }

        [JsonPropertyName("MGLT")]
        public string? MGLT { get; set; }

        [JsonPropertyName("starship_class")]
        public string? StarshipClass { get; set; }
    }
}
