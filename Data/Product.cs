using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }


    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
