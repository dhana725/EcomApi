using System.ComponentModel.DataAnnotations;

public class ProductUploadDto
{
   
    public int ProductId { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public IFormFile Image { get; set; }


    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<ProductImageUploadDto> SubImages { get; set; }
}
