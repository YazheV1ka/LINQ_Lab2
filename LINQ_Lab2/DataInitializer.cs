using LINQ_Lab2.models;

namespace LINQ_Lab2;

public class DataInitializer
{
    private readonly IDataContext _context;

    public DataInitializer(IDataContext context)
    {
        _context = context;
    }

    public void init()
    {
        _context.Categories.AddRange(new List<Category>
        {
            new Category(1, "Appetizers"),
            new Category(2, "Entrees"),
            new Category(3, "Desserts"),
            new Category(4, "Breakfast"),
            new Category(5, "Main Dishes")
        });


        _context.Products.AddRange(new List<Product>
        {
            new Product(1, "Chicken Breast", 250),
            new Product(2, "Salmon Fillet", 300),
            new Product(3, "Broccoli", 50),
            new Product(4, "Ice Cream", 200),
            new Product(5, "Chocolate", 500),
            new Product(6, "Lettuce", 10),
            new Product(7, "Beef", 230),
            new Product(8, "Bread", 321),
            new Product(9, "Apple", 52),
            new Product(10, "Cheese", 474),
            new Product(11, "Potato", 354)
        });

        _context.Dishes.AddRange(new List<Dish>
        {
            new Dish(1, "Grilled Chicken and Potatoes", 15.54, new List<Category> {_context.Categories[4]},
                new List<ProductQuantity>
                {
                    new ProductQuantity(1, 1, _context.Products[0], 1, 1),
                    new ProductQuantity(2, 11, _context.Products[10], 2, 1)
                }),
            new Dish(2, "Salmon with Broccoli", 19.99, new List<Category> {_context.Categories[1]},
                new List<ProductQuantity>
                {
                    new ProductQuantity(3, 2, _context.Products[1], 1, 2),
                    new ProductQuantity(4, 3, _context.Products[2], 1, 2)
                }),
            new Dish(3, "Chocolate Cake with Ice Cream", 8.22, new List<Category> {_context.Categories[2]},
                new List<ProductQuantity>
                {
                    new ProductQuantity(5, 4, _context.Products[3], 1, 3),
                    new ProductQuantity(6, 5, _context.Products[4], 2, 3)
                }),
            new Dish(4, "Salad", 3.93, new List<Category> {_context.Categories[1]}, new List<ProductQuantity>
            {
                new ProductQuantity(7, 2, _context.Products[1], 1, 4),
                new ProductQuantity(8, 3, _context.Products[2], 1, 4)
            }),
            new Dish(5, "Apples with Chocolate", 10.12, new List<Category> {_context.Categories[2]}, new List<ProductQuantity>
            {
                new ProductQuantity(9, 5, _context.Products[4], 2, 5),
                new ProductQuantity(10, 9, _context.Products[8], 1, 5)
            }),
            new Dish(6, "Beef Potato", 10.12, new List<Category> {_context.Categories[4]}, new List<ProductQuantity>
            {
                new ProductQuantity(11, 7, _context.Products[6], 1, 6),
                new ProductQuantity(12, 11, _context.Products[10], 3, 6)
            })
        });

        _context.Menus.AddRange(new List<Menu>
        {
            new Menu(1, DateTime.Now, 25.99,
                new List<Dish> {_context.Dishes[0], _context.Dishes[1], _context.Dishes[2]}),
            new Menu(2, DateTime.Parse("27.03.2023 13:46:34"), 30.29,
                new List<Dish> {_context.Dishes[3], _context.Dishes[4], _context.Dishes[5]})
        });
        
    }
}