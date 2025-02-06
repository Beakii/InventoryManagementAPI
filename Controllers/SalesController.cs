using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SalesController(InventoryDbContext context) : Controller
{
    private readonly DbSet<Sales> _sales = context.Sales;
    private readonly DbSet<Product> _products = context.Products;
    
    //GET
    [HttpGet]
    public IActionResult GetAllSales()
    {
        return Ok(_sales.ToList());
    }

    [HttpGet]
    public IActionResult GetSalesByProductId(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        
        var sale = _sales.Where(s => s.ProductName == product.Name);
        if (sale == null) return NotFound();
        
        return Ok(sale);
    }
    
    [HttpGet]
    public IActionResult GetSalesByProductName(string name)
    {
        var sale = _sales.Where(s => s.ProductName == name);
        if (sale == null) return NotFound();
        
        return Ok(sale);
    }
    
    
    //POST
    [HttpPost]
    public IActionResult AddSale([FromBody] Sales sale)
    {
        if (sale == null) return BadRequest();
        
        var product = _products.FirstOrDefault(p => p.Name == sale.ProductName);
        if (product == null) return BadRequest();
        
        product.Stock -= sale.SaleQuantity;
        sale.TotalPrice = sale.SaleQuantity * product.Price;
        
        _sales.Add(sale);
        _products.Update(product);
        context.SaveChanges();
        
        return Ok(sale);
    }
}