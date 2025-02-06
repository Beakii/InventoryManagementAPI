namespace InventoryManagement.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SKU { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
    
    public string SupplierName { get; set; }
    public Supplier? Supplier { get; set; }
}