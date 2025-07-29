
public class ProductRepo : IProductRepo
{
    public Task<ProductDto> AddProductAsync(ProductDto Product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> UpdateProductdAsync(ProductDto Product)
    {
        throw new NotImplementedException();
    }
}