using Azure;
using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductsController(InventoryDbContext context) : Controller
{
    private readonly DbSet<Product> _products = context.Products;
    
    
    //GET Requests
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(_products.ToList());
    }

    [HttpGet]
    public IActionResult GetProductById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        
        return Ok(product);
    }

    [HttpGet]
    public IActionResult GetProductBySku(string sku)
    {
        var product = _products.FirstOrDefault(p => p.SKU == sku);
        
        return Ok(product);
    }

    
    //POST Requests
    [HttpPost]
    public IActionResult Add([FromBody] Product newProduct)
    {
        _products.Add(newProduct);
        context.SaveChanges();
        
        return CreatedAtAction(nameof(Index), newProduct);
    }
    

    //PUT Requests
    [HttpPut]
    public IActionResult ReplaceProduct(int id, [FromBody] Product updatedProduct)
    {
        if(updatedProduct == null) return BadRequest();
        
        var product = _products.FirstOrDefault(p => p.Id == id);
        if(product == null) return BadRequest();
        
        product.Name = updatedProduct.Name;
        product.SKU = updatedProduct.SKU;
        product.Price = updatedProduct.Price;
        product.Stock = updatedProduct.Stock;
        product.Supplier = updatedProduct.Supplier;
        
        _products.Update(product);
        context.SaveChanges();
        
        return Ok(product);
    }
    
    
    //PATCH Requests
    [HttpPatch]
    public IActionResult UpdateById(int id, [FromBody] JsonPatchDocument<Product> patchDocument)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        patchDocument.ApplyTo(product);
        
        _products.Update(product);
        context.SaveChanges();
        
        return Ok(product);
    }
    
    [HttpPatch]
    public IActionResult UpdateBySku(string sku, [FromBody] JsonPatchDocument<Product> patchDocument)
    {
        var product = _products.FirstOrDefault(p => p.SKU == sku);
        if (product == null) return NotFound();

        patchDocument.ApplyTo(product);
        
        _products.Update(product);
        context.SaveChanges();
        
        return Ok(product);
    }
    
    
    //DELETE Requests
    [HttpDelete]
    public IActionResult DeleteById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        _products.Remove(product);
        context.SaveChanges();
            
        return Ok(product);
    }
    
    [HttpDelete]
    public IActionResult DeleteBySku(string sku)
    {
        var product = _products.FirstOrDefault(p => p.SKU == sku);
        if (product == null) return NotFound();

        _products.Remove(product);
        context.SaveChanges();
            
        return Ok(product);
    }
}