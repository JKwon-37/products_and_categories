using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

public class CategoriesController : Controller
{
    private ProductsAndCategoriesContext _context;

    public CategoriesController(ProductsAndCategoriesContext context)
    {
        _context = context;
    }

    [HttpGet("categories")]
    public IActionResult CategoriesPage()
    {
        List<Category> allCategories = _context.Categories.ToList();
        ViewBag.allCategories = allCategories;
        return View("CreateCategoryPage");
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category category)
    {
        if(ModelState.IsValid)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return CategoriesPage();
    }
}