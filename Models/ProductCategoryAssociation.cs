#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class ProductCategoryAssociation
{
    [Key]
    public int ProductCategoryAssociationId {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int ProductId {get;set;}
    public Product? Product {get;set;}

    [Display(Name = "Add Category: ")]
    public int CategoryId {get;set;}
    public Category? Category {get;set;}
}