using System.ComponentModel.DataAnnotations;

public class ProductImage
{
      [Key]
    public int ProductImgId { get; set; }

    public int ProductId { get; set; }             // Foreign key to Product
    public string ImageUrl { get; set; }
    public int ImgOrder { get; set; }

    public Product Product { get; set; } 
}