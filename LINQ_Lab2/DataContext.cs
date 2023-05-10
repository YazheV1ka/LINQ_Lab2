using LINQ_Lab2.models;

namespace LINQ_Lab2;

public class DataContext : IDataContext
{
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<Dish> Dishes { get; set; } = new List<Dish>();
    public List<Menu> Menus { get; set; } = new List<Menu>();
    public List<Product> Products { get; set; } = new List<Product>();
    public List<ProductQuantity> ProductQuantities { get; set; } = new List<ProductQuantity>();
}