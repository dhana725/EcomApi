
using Microsoft.EntityFrameworkCore;

public class CategoryRepo : ICategoryRepo
{
    private readonly EcomDbContex _context;
    public CategoryRepo(EcomDbContex context)
    {
        _context = context;
    }

    public async Task AddcategoryAsync(CategoryDto category)
    {
        if (category == null)
            throw new ArgumentNullException(nameof(category), "Category cannot be null.");

        var cat = new Category
        {
            Name = category.Name,
            Image = category.Image
        };

        await _context.Categories.AddAsync(cat);
        await _context.SaveChangesAsync();
    }

    public Task DeletecategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryDto>> GetcategoryAsync()
    {
        var result = await _context.Categories.Select(c => new CategoryDto { CategoryId = c.CategoryId, Name = c.Name, Image = c.Image }).ToListAsync();
        return result;
    }

    public Task<CategoryDto> GetcategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> UpdatecategorydAsync(CategoryDto category)
    {
        throw new NotImplementedException();
    }
}