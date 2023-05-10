using System.Globalization;
using System.Xml.Linq;
using LINQ_Lab2.models;

namespace LINQ_Lab2;

public class DataQueries
{
    private static XDocument _document;

    public DataQueries(XDocument document)
    {
        _document = document;
    }

    // Query 1: Get all the dishes that contain an ingredient
    public void GetDishesWithAnIngredient(string ingredient)
    {
        var query = from dish in _document.Descendants("Dish")
            where dish.Descendants("Ingredients").Descendants("Product")
                .Any(prod => prod.Element("Name").Value == ingredient)
            group dish by dish.Element("Name").Value
            into dishGroup
            select dishGroup.First();

        foreach (var dish in query)
        {
            Console.WriteLine("Dish: " + dish.Element("Name").Value + ", Ingredient: " + ingredient);
        }
    }

// Query 2: Get all the desserts
    public void GetDesserts()
    {
        var query = from dish in _document.Descendants("Dish").Where(dish =>
                dish.Descendants("Category")
                    .Any(categ => categ.Element("Name")?.Value == "Desserts"))
            group dish by dish.Element("Name").Value
            into dishGroup
            select dishGroup.First();

        foreach (var dish in query)
        {
            Console.WriteLine("Dish: " + dish.Element("Name").Value);
        }
    }

// Query 3: Get the total number of calories in a menu
    public void GetTotalCaloriesInMenu()
    {
        var totalCalories = _document.Descendants("Dish")
            .Descendants("ProductQuantity")
            .Sum(p => (int) p.Element("Product").Element("Calories") * (int) p.Element("Quantity"));

        Console.WriteLine($"Total calories in the menu: {totalCalories}");
    }

// Query 4: Get the average price of a dish
    public void GetAverageDishPrice()
    {
        var averagePrice = _document.Descendants("Dish").Average(dish => (double) dish.Element("Price"));

        Console.WriteLine($"The average price of dishes is: {averagePrice}");
    }

// Query 5: Get the most expensive dish
    public void GetMostExpensiveDish()
    {
        var mostExpensiveDish = _document.Descendants("Dish").MaxBy(dish => (double) dish.Element("Price")!)!
            .Deserialize<Dish>();
        Console.WriteLine(
            $"The most expensive dish is {mostExpensiveDish.Name} and it costs {mostExpensiveDish.Price} dollars.");
    }

// Query 6: Get the cheapest dessert
    public void GetCheapestDessert()
    {
        var cheapestDessert = _document.Descendants("Dish")
            .Where(d => d.Descendants("Category").Any(c => c.Element("Name").Value == "Desserts"))
            .MinBy(d => (double) d.Element("Price")!)?.Deserialize<Dish>();


        Console.WriteLine(
            $"The cheapest dessert is {cheapestDessert.Name} and it costs {cheapestDessert.Price} dollars.");
    }


// Query 7: Get all products where calories > 200
    public void GetHighCalorieProducts()
    {
        var highCalorieProducts = _document.Descendants("Product")
            .Where(product => (int) product.Element("Calories") > 200)
            .Select(product => product.Element("Name").Value)
            .Distinct()
            .ToList();

        Console.WriteLine($"Products with more than 200 calories:");
        foreach (var productName in highCalorieProducts)
        {
            Console.WriteLine($"- {productName}");
        }
    }

// Query 8: Get all categories with broccoli
    public void GetCategoriesWithBroccoli()
    {
        var categoriesWithBroccoli = _document.Descendants("Category")
            .Where(cat => _document.Descendants("Dish")
                .Where(dish => dish.Descendants("Category")
                    .Any(categ => categ.Element("Id").Value == cat.Element("Id").Value))
                .Any(dish => dish.Descendants("Ingredients")
                    .Any(ingr => ingr.Descendants("Product")
                        .Any(prod => prod.Element("Name").Value == "Broccoli"))))
            .GroupBy(cat => cat.Element("Id").Value)
            .Select(group => group.First())
            .ToList();

        foreach (var category in categoriesWithBroccoli)
        {
            Console.WriteLine($"- {category.Element("Name").Value}");
        }
    }


// Query 9: Get all dishes with no chocolate
    public void GetDishesWithNoChocolate()
    {
        var dishesWithNoChocolate = _document.Descendants("Dish")
            .Where(d => d.Descendants("Ingredient")
                .All(pq => pq.Descendants("Product")
                    .Any(p => p.Attribute("Name").Value != "Chocolate")))
            .Select(d => new {Name = d.Element("Name").Value})
            .Distinct()
            .ToList();
        Console.WriteLine($"Dishes without chocolate:");
        foreach (var dish in dishesWithNoChocolate)
        {
            Console.WriteLine($"- {dish.Name}");
        }
    }

// Query 10: Get number of dishes
    public void GetNumberOfDishes()
    {
        var numberOfDishes = _document.Descendants("Dish").Count();
        Console.WriteLine($"There are {numberOfDishes} dishes.");
    }

// Query 11: Union Dishes And Products
    public void GetUnionDishesAndProducts()
    {
        var unionDishesAndProducts = _document.Descendants("Dish").Select(dish => (string) dish.Element("Name"))
            .Union(_document.Descendants("Product").Select(product => (string) product.Element("Name"))).ToList();
        Console.WriteLine($"Union of dish and product names:");
        foreach (var name in unionDishesAndProducts)
        {
            Console.WriteLine($"- {name}");
        }
    }

// Query 12: Get Dishes With Name Contains
    public void GetDishesWithNameContains(string search)
    {
        var dishes = _document.Descendants("Dish")
            .Where(d => d.Element("Name").Value.Contains(search))
            .Select(d => new Dish
            {
                Id = int.Parse(d.Element("Id").Value),
                Name = d.Element("Name").Value,
                Price = double.Parse(d.Element("Price").Value, CultureInfo.InvariantCulture),
                Categories = d.Descendants("Category")
                    .Select(c => new Category
                    {
                        Id = int.Parse(c.Element("Id").Value),
                        Name = c.Element("Name").Value
                    })
                    .ToList(),
                Ingredients = d.Descendants("ProductQuantity")
                    .Select(pq => new ProductQuantity
                    {
                        Id = int.Parse(pq.Element("Id").Value),
                        Quantity = int.Parse(pq.Element("Quantity").Value),
                        Product = new Product
                        {
                            Id = int.Parse(pq.Element("Product").Element("Id").Value),
                            Name = pq.Element("Product").Element("Name").Value,
                            Calories = int.Parse(pq.Element("Product").Element("Calories").Value),
                        }
                    }).Distinct()
                    .ToList()
            }).Distinct()
            .ToList();


        Console.WriteLine($"Dish with {search}: {dishes[0].Name} , Price: {dishes[0].Price}");
        Console.WriteLine("Categories:");
        Console.WriteLine($"- {dishes[0].Categories[0].Name} ");

        Console.WriteLine("Ingredients:");
        foreach (var ingredient in dishes[0].Ingredients)
        {
            Console.WriteLine(
                $"- {ingredient.Product.Name} , Quantity: {ingredient.Quantity}, Calories: {ingredient.Product.Calories}");
        }

        Console.WriteLine();
    }


// Query 13: Get All Dish Information
    public void GetAllDishInfo(int dishId)
    {
        var dish = _document.Descendants("Dish")
            .FirstOrDefault(d => (int) d.Element("Id") == dishId);

        if (dish != null)
        {
            Console.WriteLine($"Dish: {dish.Element("Name").Value} (ID: {dish.Element("Id").Value})");
            Console.WriteLine("Ingredients:");

            var ingredients = dish.Descendants("ProductQuantity")
                .Select(pq => new
                {
                    ProductId = (int) pq.Element("ProductId"),
                    Quantity = (int) pq.Element("Quantity")
                });

            foreach (var ingredient in ingredients)
            {
                var product = _document.Descendants("Product")
                    .FirstOrDefault(p => (int) p.Element("Id") == ingredient.ProductId);

                if (product != null)
                {
                    Console.WriteLine($"- {product.Element("Name").Value} ({ingredient.Quantity}x)");
                }
            }
        }
        else
        {
            Console.WriteLine($"Dish with ID {dishId} not found.");
        }
    }


// Query 14: Order by Price in Dishes
    public void OrderbyPriceinDishes()
    {
        var dishes = _document.Descendants("Dish")
            .OrderBy(d => (double) d.Element("Price"))
            .GroupBy(d => d.Element("Name").Value)
            .Select(d => d.First())
            .ToList();

        foreach (var dish in dishes)
        {
            Console.WriteLine(
                $"Dish: {dish.Element("Name").Value} , Price: {dish.Element("Price").Value}");
            Console.WriteLine("Categories:");
            foreach (var category in dish.Descendants("Category"))
            {
                Console.WriteLine($"- {category.Element("Name").Value} ");
            }

            
            Console.WriteLine();
        }
    }


// Query 15: Group by Date in Menu
    public void GroupbyDateinMenu()
    {
        var groups = _document.Descendants("Menu").GroupBy(m => (DateTime) m.Element("Date"))
            .Select(g => new {Date = g.Key, Count = g.Count()})
            .ToList();

        foreach (var group in groups)
        {
            Console.WriteLine($"- {group.Date}: {group.Count}");
        }
    }
}