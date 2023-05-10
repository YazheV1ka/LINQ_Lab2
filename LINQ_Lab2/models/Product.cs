namespace LINQ_Lab2.models;


[Serializable]
public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Calories { get; set; }

    public Product() {}
    public Product(int id, string? name, int calories)
    {
        Id = id;
        Name = name;
        Calories = calories;
    }
}