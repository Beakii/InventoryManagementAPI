using InventoryManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers;

public class SupplierController(InventoryDbContext context) : Controller
{
    private readonly DbSet<Supplier> _suppliers = context.Suppliers;

    public IActionResult Index()
    {
        return Ok("Supplier API controller is up and running.");
    }

    //GET Requests
    [HttpGet]
    public IActionResult GetAllSuppliers()
    {
        return Ok(_suppliers.ToList());
    }

    [HttpGet]
    public IActionResult GetSupplierById(int id)
    {
        var supplier = _suppliers.FirstOrDefault(s => s.Id == id);
        
        return Ok(supplier);
    }

    [HttpGet]
    public IActionResult GetSupplierByName(string name)
    {
        var supplier = _suppliers.FirstOrDefault(s => s.Name == name);
        
        return Ok(supplier);
    }
    
    
    //POST Requests
    
    //PUT Requests
    
    //PATCH Requests
    
    //DELETE Requests
}