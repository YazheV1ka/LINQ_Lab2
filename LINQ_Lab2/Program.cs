using System.Xml.Linq;

namespace LINQ_Lab2;

public static class Program
{
    public static void Main(string[] args)
    {
        DataContext _dataContext = new DataContext();
        DataInitializer _dataInitializer = new DataInitializer(_dataContext);
        _dataInitializer.init();
        FileWorker fileWorker = new FileWorker(_dataContext);
        fileWorker.create("data.xml");
        var document = XDocument.Parse(File.ReadAllText("data.xml"));
        var dataQueries = new DataQueries(document);

        // Query 1: Get all the dishes that contain an ingredient
        ChangeColorForQueryTitle("\n1. Get all the dishes that contain an ingredient");
        dataQueries.GetDishesWithAnIngredient("Potato");

        // Query 2: Get all the desserts
        ChangeColorForQueryTitle("\n2. Get all the desserts");
        dataQueries.GetDesserts();

        // Query 3: Get the total number of calories in a menu
        ChangeColorForQueryTitle("\n3. Get the total number of calories in a menus");
        dataQueries.GetTotalCaloriesInMenu();

        // Query 4: Get the average price of a dish
        ChangeColorForQueryTitle("\n4: Get the average price of a dish");
        dataQueries.GetAverageDishPrice();

        // Query 5: Get the most expensive dish
        ChangeColorForQueryTitle("\n5: Get the most expensive dish");
        dataQueries.GetMostExpensiveDish();

        // Query 6: Get the cheapest dessert
        ChangeColorForQueryTitle("\n6: Get the cheapest dessert");
        dataQueries.GetCheapestDessert();

        // Query 7: Get all products where calories > 200
        ChangeColorForQueryTitle("\n7: Get all products where calories > 200");
        dataQueries.GetHighCalorieProducts();

        // Query 8: Get all categories with broccoli 
        ChangeColorForQueryTitle("\n8: Get all categories with broccoli");
        dataQueries.GetCategoriesWithBroccoli();

        // Query 9: Get all dishes with no chocolate 
        ChangeColorForQueryTitle("\n9: Get all dishes with no chocolate");
        dataQueries.GetDishesWithNoChocolate();

        // Query 10: Get number of dishes
        ChangeColorForQueryTitle("\n10: Get number of dishes");
        dataQueries.GetNumberOfDishes();

        // Query 11: Union Dishes And Products
        ChangeColorForQueryTitle("\n11: Union Dishes And Products");
        dataQueries.GetUnionDishesAndProducts();

        // Query 12: Get Dishes With Name Contains
        ChangeColorForQueryTitle("\n12: Get Dishes With Name Contains");
        dataQueries.GetDishesWithNameContains("Chicken");

        // Query 13: Get All Dish Information
        ChangeColorForQueryTitle("\n13: Get All Dish Information");
        dataQueries.GetAllDishInfo(1);

        // Query 14: Order by Price in Dishes
        ChangeColorForQueryTitle("\n14: Order by Price in Dishes");
        dataQueries.OrderbyPriceinDishes();

        // Query 15: Group by Date in Menu
        ChangeColorForQueryTitle("\n15: Group by Date in Menu");
        dataQueries.GroupbyDateinMenu();
    }


    private static void ChangeColorForQueryTitle(string queryName)
    {
        // встановлюємо колір
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(queryName);
        Console.ResetColor();
    }
}