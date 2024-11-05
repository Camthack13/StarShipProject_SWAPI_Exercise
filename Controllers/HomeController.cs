using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarshipProject;
using StarshipProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
//using Newtonsoft.Json;

namespace StarshipProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly StarshipContext _context;

        public HomeController(StarshipContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(bool refreshRandom = false)
{
    var starships = await _context.Starships.ToListAsync();
    Starship? randomStarship = null;

    if (starships.Any())
    {
        if (refreshRandom || HttpContext.Session.Get<Starship>("RandomStarship") == null)
        {
            var random = new Random();
            randomStarship = starships[random.Next(starships.Count)];
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
        AllStarships = starships
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
