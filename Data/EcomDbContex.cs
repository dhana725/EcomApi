using Microsoft.EntityFrameworkCore;

public class EcomDbContex : DbContext
{
    public EcomDbContex(DbContextOptions<EcomDbContex> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImage { get; set; }

    
}