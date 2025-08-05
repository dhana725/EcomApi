public interface IProductRepo
{
    Task<Product> AddProductAsync(Product Product);
     Task AddSubProductAsync(ProductImage subProduct);
    Task<IEnumerable<ProductDto>> GetProductAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
    Task<ProductDto> UpdateProductdAsync(ProductDto Product);
    Task DeleteProductAsync(int id);

}