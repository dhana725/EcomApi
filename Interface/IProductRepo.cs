public interface IProductRepo
{
    Task<ProductDto> AddProductAsync(ProductDto Product);
    Task<IEnumerable<ProductDto>> GetProductAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
    Task<ProductDto> UpdateProductdAsync(ProductDto Product);
    Task DeleteProductAsync(int id);

}