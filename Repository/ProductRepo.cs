
using Microsoft.EntityFrameworkCore;

public class ProductRepo : IProductRepo
{
     private readonly EcomDbContex _context;
    public ProductRepo(EcomDbContex context)
    {
        _context = context;
    }
    public async Task<Product> AddProductAsync(Product Product)
    {

        if (Product == null)
            throw new ArgumentNullException(nameof(Product), "Product cannot be null.");
        await _context.Products.AddAsync(Product);
        await _context.SaveChangesAsync();
      return await _context.Products
    .FirstOrDefaultAsync(p => p.ProductId == Product.ProductId);
    }

    public async Task AddSubProductAsync(ProductImage subProduct)
    {
          await _context.ProductImage.AddAsync(subProduct);
        await _context.SaveChangesAsync();
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