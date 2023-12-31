using CocktailsAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocktailsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CocktailsController : ControllerBase
{
    protected readonly IConfiguration Configuration;

    private readonly ILogger<WeatherForecastController> _logger;

    public CocktailsController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
    {
        _logger = logger;
        Configuration = configuration;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DrinkDbModel>> GetCocktailInfo(int id)
    {
        DrinksDbContext dbContext = new DrinksDbContext(configuration:Configuration);
        var result = await dbContext.Drinks.Where(d => d.Id == id).Include(d => d.Ingredients).ThenInclude(ingredient => ingredient.Ingredient).FirstAsync();
        return  result;
    }

    [HttpGet]
    public IActionResult GetCocktailsByName([FromQuery] string name)
    {
        DrinksDbContext dbContext = new DrinksDbContext(configuration:Configuration);

        var results = dbContext.Drinks.Where(d => d.Name.ToLower().StartsWith(name.ToLower())).ToList();
        if (results.Count == 0)
        {
            return NotFound("No cocktails found");
        }

        return Ok(results);
    }
}