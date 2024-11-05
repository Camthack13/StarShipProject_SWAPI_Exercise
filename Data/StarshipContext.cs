using Microsoft.EntityFrameworkCore;
using StarshipProject.Models;

public class StarshipContext : DbContext
{
    public StarshipContext(DbContextOptions<StarshipContext> options)
        : base(options)
    {
    }

    public DbSet<Starship> Starships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*
        // Seed data
        modelBuilder.Entity<Starship>().HasData(
            new Starship { Id = 1, Name = "Millennium Falcon", Model = "YT-1300 light freighter", Manufacturer = "Corellian Engineering Corporation", StarshipClass = "Light freighter" },
            new Starship { Id = 2, Name = "X-Wing", Model = "T-65 X-wing starfighter", Manufacturer = "Incom Corporation", StarshipClass = "Starfighter" },
            new Starship { Id = 3, Name = "TIE Fighter", Model = "Twin Ion Engine starfighter", Manufacturer = "Sienar Fleet Systems", StarshipClass = "Starfighter" }
        );
        */
    } 
}
