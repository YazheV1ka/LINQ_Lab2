namespace LINQ_Lab2.models;

[Serializable]
public class ProductQuantity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public int DishId { get; set; }

    public ProductQuantity() {}

    public ProductQuantity(int id, int productId, Product? product, int quantity, int dishId)
    {
        Id = id;
        ProductId = productId;
        Product = product;
        Quantity = quantity;
        DishId = dishId;
    }
}