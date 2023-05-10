using LINQ_Lab2.models;

namespace LINQ_Lab2;

public interface IDataContext
{
     List<Category> Categories { get; set; } 
     List<Dish> Dishes { get; set; } 
     List<Menu> Menus { get; set; } 
     List<Product> Products { get; set; } 
     List<ProductQuantity> ProductQuantities { get; set; }
}