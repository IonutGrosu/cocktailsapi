using System.ComponentModel.DataAnnotations.Schema;
public class DrinkIngredientDbModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int DrinkId { get; set; }
    public DrinkDbModel Drink { get; set; }
    public int IngredientId { get; set; }
    public IngredientDbModel Ingredient { get; set; }
    public string Measurement { get; set; }
}