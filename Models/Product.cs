namespace InventoryManagement.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SKU { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public Supplier Supplier { get; set; }
}