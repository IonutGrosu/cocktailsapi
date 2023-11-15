using Microsoft.EntityFrameworkCore;

namespace CocktailsAPI.Data;

public class DrinksDbContext: DbContext
{
    protected readonly IConfiguration Configuration;

    public DrinksDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Fl0Postgres");

        optionsBuilder.UseNpgsql(connectionString);
    }
    
    public DbSet<DrinkDbModel> Drinks { get; set; }
    public DbSet<IngredientDbModel> Ingredients { get; set; }
    public DbSet<DrinkIngredientDbModel> DrinkIngredients { get; set; }
}