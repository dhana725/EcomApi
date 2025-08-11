using System.ComponentModel.DataAnnotations;

public class ProductImageUploadDto
{
    public int ProductImgId { get; set; }

    public int ProductId { get; set; }             // Foreign key to Product
    public IFormFile ImageUrl { get; set; }
    public int ImgOrder { get; set; }

    public Product Product { get; set; } 
}