namespace LINQ_Lab2.models;

[Serializable]
public class Menu
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public List<Dish>? Dishes { get; set; }

    public Menu() {}
    public Menu(int id, DateTime date, double price, List<Dish>? dishes)
    {
        Id = id;
        Date = date;
        Price = price;
        Dishes = dishes;
    }
}