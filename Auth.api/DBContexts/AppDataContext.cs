using Microsoft.EntityFrameworkCore;
using Auth.models;

namespace Auth.api.DBContexts;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    { }

    public DbSet<ProductModel> ProductData { get; set; }
    public DbSet<CategoryModel> CategoryData { get; set; }
    public DbSet<ShopCartModel> ShopCartData { get; set; }
}