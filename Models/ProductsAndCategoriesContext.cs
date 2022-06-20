#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategories.Models;
// the ProjectNameContext class representing a session with our MySQL database, allowing us to query for or save data
public class ProductsAndCategoriesContext : DbContext 
{ 
    public ProductsAndCategoriesContext(DbContextOptions options) : base(options) { }

    // the "TableName" table name will come from the DbSet property name
    // add DbSet<> properties below
    //public DbSet<Example> Examples { get; set; } 
}