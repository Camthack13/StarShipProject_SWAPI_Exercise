namespace StarshipProject.Models
{
    public class HomePageViewModel
    {
        public Starship? RandomStarship { get; set; }
        public List<Starship> AllStarships { get; set; } = new List<Starship>();
    }
}
