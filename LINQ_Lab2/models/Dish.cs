namespace LINQ_Lab2.models;

[Serializable]
public class Dish
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public List<Category>? Categories { get; set; }
    public List<ProductQuantity>? Ingredients { get; set; }

    public Dish() {}

    public Dish(int id, string? name, double price, List<Category>? categories, List<ProductQuantity>? ingredients)
    {
        Id = id;
        Name = name;
        Price = price;
        Categories = categories;
        Ingredients = ingredients;
    }
}