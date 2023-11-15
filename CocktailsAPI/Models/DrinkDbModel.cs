public class DrinkDbModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public bool IsAlcoholic { get; set; }
    public string Glass { get; set; }
    public string Instructions { get; set; }
    public string ImageThumbnail { get; set; }
    public List<DrinkIngredientDbModel> Ingredients { get; set; }
    
    public override string ToString()
    {
        return $"Drink Id: {Id}\nName: {Name}\nCategory: {Category}\nIs Alcoholic: {IsAlcoholic}\nGlass: {Glass}\nInstructions: {Instructions}\nImage Thumbnail: {ImageThumbnail}";
    }
}