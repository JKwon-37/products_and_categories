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
    public IActionResult ViewProduct(int productId)
    {
        Product? AProduct = _context.Products
        .Include(prod => prod.ManyCats)
        .ThenInclude(cat => cat.Category).FirstOrDefault(prod => prod.ProductId == productId);

        return View("ViewProduct", AProduct);
    }

    [HttpPost("products/{productId}/add")]
    public IActionResult AddCatToProd(int productId, ProductCategoryAssociation Id)
    {
        ProductCategoryAssociation? ExistingCatForProd = _context.Associations.FirstOrDefault(newCat => newCat.ProductId == productId);
        List<Category> listCats = _context.Categories.ToList();
        ViewBag.listCats = listCats;
        if(ExistingCatForProd == null)
        {
            ProductCategoryAssociation AddCatToProd = new ProductCategoryAssociation()
            {
                ProductId = productId,
                CategoryId = Id.CategoryId
            };
            _context.Associations.Add(AddCatToProd);
            _context.SaveChanges();
        }
            return View("AddCatToProd");
    }
}