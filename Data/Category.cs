using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    public string Image { get; set; }

    public ICollection<Product> Products { get; set; }
}
