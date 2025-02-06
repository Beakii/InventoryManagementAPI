namespace InventoryManagement.Models;

public class Sales
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int SaleQuantity { get; set; }
    public float? TotalPrice { get; set; }
}