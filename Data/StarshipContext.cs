using Microsoft.EntityFrameworkCore;
using StarshipProject.Models;

public class StarshipContext : DbContext
{
    public StarshipContext(DbContextOptions<StarshipContext> options)
        : base(options)
    {
    }

    public DbSet<Starship> Starships { get; set; }

}
