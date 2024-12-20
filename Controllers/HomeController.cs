using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarshipProject.Models;
using System.Text.Json;


namespace StarshipProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly StarshipContext _context;

        public HomeController(StarshipContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortColumn = "Name", string sortOrder = "asc", bool refreshRandom = false)
        {

            ViewData["SortOrder_Name"] = sortColumn == "Name" ? sortOrder : "asc";
            ViewData["SortOrder_Model"] = sortColumn == "Model" ? sortOrder : "asc";
            ViewData["SortOrder_Class"] = sortColumn == "Class" ? sortOrder : "asc";
            
          
            // Get all starships from the database for all starships list as queryable for sorting
            var starships = _context.Starships.AsQueryable();

            // Apply sorting based on the sortColumn and sortOrder
            starships = sortColumn switch
            {
                "Name" => sortOrder == "asc" ? starships.OrderBy(s => s.Name) : starships.OrderByDescending(s => s.Name),
                "Model" => sortOrder == "asc" ? starships.OrderBy(s => s.Model) : starships.OrderByDescending(s => s.Model),
                "Class" => sortOrder == "asc" ? starships.OrderBy(s => s.StarshipClass) : starships.OrderByDescending(s => s.StarshipClass),
                _ => starships.OrderBy(s => s.Name) // Default to Name if no sort column specified
            };

            // Saving the sorted data as a regular list of starships
            var starshipsList = await starships.ToListAsync();

            //get list of starships to pick random
            var starshipListForRand = await _context.Starships.ToListAsync();

            Starship? randomStarship = null;

            if (starshipListForRand.Any())
            {
                if (refreshRandom || HttpContext.Session.Get<Starship>("RandomStarship") == null)
                {
                    var random = new Random();
                    randomStarship = starshipListForRand[random.Next(starshipListForRand.Count)];
                    HttpContext.Session.Set("RandomStarship", randomStarship); // Save random starship in session
                }
                else
                {
                    randomStarship = HttpContext.Session.Get<Starship>("RandomStarship"); // Retrieve from session
                }
            }

            // Pass the random starship and the list of all starships to the view
            var model = new HomePageViewModel
            {
                RandomStarship = randomStarship,
                AllStarships = starshipsList
            };

            return View(model);
        }

    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
