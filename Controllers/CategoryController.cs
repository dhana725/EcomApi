using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class CategoryController : ControllerBase
{
    private readonly ICategoryRepo _repo;
    public CategoryController(ICategoryRepo repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllcategory()
    {
        var category = await _repo.GetcategoryAsync();
        return Ok(category);
    }
    [HttpPost]
    public async Task<IActionResult> PostCategory([FromForm] IFormFile image, [FromForm] string name)
{
    if (image == null || image.Length == 0)
        return BadRequest("No image uploaded.");

    var folderName = "CategoryImage"; // or generate dynamically
    var uploadPath = Path.Combine("/Users/dhananjayanayak/EcomUI/", "src", "assets", folderName);

    if (!Directory.Exists(uploadPath))
        Directory.CreateDirectory(uploadPath);

    var fileName = $"{name}_{Path.GetFileName(image.FileName)}";
    var filePath = Path.Combine(uploadPath, fileName);

    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await image.CopyToAsync(stream);
    }

    var imageRecord = new CategoryDto
    {
        Name = name,
        Image = Path.Combine("./assets", folderName, fileName)
    };

   await _repo.AddcategoryAsync(imageRecord);

    return Ok(new { message = "Category Uploaded Successfully" });
}
}