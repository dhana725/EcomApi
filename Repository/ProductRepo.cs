
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

    public async Task<IEnumerable<ProductDto>> GetProductAsync()
    {
       var data = await _context.Products
        .Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Price = p.Price,
            CategoryId = p.CategoryId,
            Image =p.Image,
            SubImages = _context.ProductImage
                .Where(pi => pi.ProductId == p.ProductId)
                .Select(pi => new ProductSubImageDto
                {
                    ImageUrl = pi.ImageUrl,
                    ImgOrder = pi.ImgOrder,
                    ProductId = pi.ProductId

                })
                .ToList()
        })
        .ToListAsync();

    return data;
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