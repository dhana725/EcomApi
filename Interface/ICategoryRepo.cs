public interface ICategoryRepo
{
    Task AddcategoryAsync(CategoryDto category);
    Task<IEnumerable<CategoryDto>> GetcategoryAsync();
    Task<CategoryDto> GetcategoryByIdAsync(int id);
    Task<CategoryDto> UpdatecategorydAsync(CategoryDto category);
    Task DeletecategoryAsync(int id);

}