using Auth.api.DBContexts;
using Auth.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth.api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly AppDataContext _applicationDbContext;

    public ProductController(ILogger<ShopCartController> logger, AppDataContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet]
    public async Task<List<ProductModel>?> GetAllProducts()
    {
        var products = await _applicationDbContext.ProductData.ToListAsync();

        return products;
    }

    [HttpGet]
    public async Task<List<ProductModel>?> GetCategoryProducts(int id)
    {
        var catProducts = await _applicationDbContext.ProductData.Where(Product => Product.Category.Id == id).ToListAsync();

        return catProducts;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductModel newProduct)
    {
        _applicationDbContext.Add(newProduct);

        await _applicationDbContext.SaveChangesAsync();

        return Ok();
    }
}

