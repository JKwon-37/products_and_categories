using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

public class ProductsController : Controller
{
    private ProductsAndCategoriesContext _context;

    public ProductsController(ProductsAndCategoriesContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public IActionResult ProductsPage()
    {
        List<Product> productsList = _context.Products.ToList();
        ViewBag.productsList = productsList;
        return View("CreateProductPage");
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product product)
    {
        if(ModelState.IsValid)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return ProductsPage();
    }

    [HttpGet("products/{productId}")]
    public IActionResult ViewProduct()
    {

        return View("ViewProduct");
    }

    [HttpGet("products/{productId}/delete")]
    public IActionResult DeleteProduct()
    {
        
    }
}