using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarshipProject.Models;

public class StarshipsController : Controller
{
    private readonly StarshipContext _context;

    public StarshipsController(StarshipContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var starships = await _context.Starships.ToListAsync();
        return View(starships);
    }

    public async Task<IActionResult> Random()
    {
        var starships = await _context.Starships.ToListAsync();
        if (starships.Count == 0) return RedirectToAction("Index");

        var random = new Random();
        var randomStarship = starships[random.Next(starships.Count)];

        return View(randomStarship);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Starship starship)
    {
        if (ModelState.IsValid)
        {
            _context.Add(starship);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(starship);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var starship = await _context.Starships.FindAsync(id);
        if (starship == null) return NotFound();
        return View(starship);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Starship starship)
    {
        if (id != starship.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(starship);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(starship);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var starship = await _context.Starships.FindAsync(id);
        if (starship != null)
        {
            _context.Starships.Remove(starship);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index", "Home"); // Redirects to the homepage
    }

    public async Task<IActionResult> Details(int id)
    {
        var starship = await _context.Starships.FindAsync(id);
        if (starship == null)
        {
            return NotFound();
        }
        return View(starship);
    }


}
