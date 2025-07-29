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

    public async Task<ActionResult> PostCategory([FromBody] CategoryDto Category)
    {
        await _repo.AddcategoryAsync(Category);
        return Ok(new { message = "Category created successfully" });
    }
}