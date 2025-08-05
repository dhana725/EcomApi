using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase
{

    private readonly IProductRepo _repo;
    public ProductController(IProductRepo repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllProducts()
    {
        var category = await _repo.GetProductAsync();
        return Ok(category);
    }
    [HttpPost]
    public async Task<IActionResult> UploadProduct([FromForm] ProductDto model)
    {

        try
        {
            if (model == null)
                return BadRequest("Model is null");

            if (model.Image == null)
                return BadRequest("Main product image is missing");
            var folderName = "ProductImage"; // or generate dynamically
            var uploadPath = Path.Combine("/Users/dhananjayanayak/EcomUI/", "src", "assets", folderName);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = $"{model.Name}_{Path.GetFileName(model.Image.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.Image.CopyToAsync(stream);
            }
            if (model.SubImages == null || !model.SubImages.Any())
                return BadRequest("SubImages not received");

            // Save main product
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Image = Path.Combine("./assets", folderName, fileName)
            };

            var res = await _repo.AddProductAsync(product);
            var subfolderName = "ProductSubImages"; // or generate dynamically
            var subploadPath = Path.Combine("/Users/dhananjayanayak/EcomUI/", "src", "assets", subfolderName);

            if (!Directory.Exists(subploadPath))
                Directory.CreateDirectory(subploadPath);
            foreach (var sub in model.SubImages)
            {

                if (sub.Image == null)
                    continue;
                var subfileName = $"{sub.ImgOrder}_{Path.GetFileName(sub.Image.FileName)}";
                var subfilePath = Path.Combine(subploadPath, subfileName);

                using (var stream = new FileStream(subfilePath, FileMode.Create))
                {
                    await sub.Image.CopyToAsync(stream);
                }

                var subImg = new ProductImage
                {

                    ImgOrder = sub.ImgOrder,
                    ImageUrl = Path.Combine("./assets", subfolderName, subfileName),
                    ProductId= res.ProductId
                };
                 await _repo.AddSubProductAsync(subImg);
            }


            return Ok(new { message = "Upload successful" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Server error: {ex.Message}");
        }


    }
}
