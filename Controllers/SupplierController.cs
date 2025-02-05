using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SupplierController(InventoryDbContext context) : Controller
{
    private readonly DbSet<Supplier> _suppliers = context.Suppliers;

    [HttpGet]
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
    [HttpPost]
    public IActionResult Add([FromBody] Supplier newSupplier)
    {
        _suppliers.Add(newSupplier);
        context.SaveChanges();
        
        return CreatedAtAction(nameof(Index), newSupplier);
    }
    
    //PUT Requests
    [HttpPut]
    public IActionResult ReplaceSupplier(int id, [FromBody] Supplier updatedSupplier)
    {
        if(updatedSupplier == null) return BadRequest();
        
        var supplier = _suppliers.FirstOrDefault(p => p.Id == id);
        if(supplier == null) return BadRequest();
        
        supplier.Name = updatedSupplier.Name;
        supplier.ContactInfo = updatedSupplier.ContactInfo;
        
        _suppliers.Update(supplier);
        context.SaveChanges();
        
        return Ok(supplier);
    }
    
    
    //PATCH Requests
    [HttpPatch]
    public IActionResult UpdateById(int id, [FromBody] JsonPatchDocument<Supplier> patchDocument)
    {
        var supplier = _suppliers.FirstOrDefault(p => p.Id == id);
        if (supplier == null) return NotFound();

        patchDocument.ApplyTo(supplier);
        
        _suppliers.Update(supplier);
        context.SaveChanges();
        
        return Ok(supplier);
    }
    
    [HttpPatch]
    public IActionResult UpdateByName(string name, [FromBody] JsonPatchDocument<Supplier> patchDocument)
    {
        var supplier = _suppliers.FirstOrDefault(p => p.Name == name);
        if (supplier == null) return NotFound();

        patchDocument.ApplyTo(supplier);
        
        _suppliers.Update(supplier);
        context.SaveChanges();
        
        return Ok(supplier);
    }
    
    
    //DELETE Requests
    [HttpDelete]
    public IActionResult DeleteById(int id)
    {
        var supplier = _suppliers.FirstOrDefault(p => p.Id == id);
        if (supplier == null) return NotFound();

        _suppliers.Remove(supplier);
        context.SaveChanges();
            
        return Ok(supplier);
    }
    
    
    [HttpDelete]
    public IActionResult DeleteByName(string name)
    {
        var supplier = _suppliers.FirstOrDefault(p => p.Name == name);
        if (supplier == null) return NotFound();

        _suppliers.Remove(supplier);
        context.SaveChanges();
            
        return Ok(supplier);
    }
}