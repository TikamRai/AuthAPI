using Auth.api.DBContexts;
using Auth.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth.api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class ShopCartController : ControllerBase
{
    private readonly AppDataContext _applicationDbContext;

    public ShopCartController(ILogger<ShopCartController> logger, AppDataContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet]
    public async Task<List<ProductModel>?> GetProductsFromCart()
    {
        var user = User.Identity?.Name ?? string.Empty;

        var shopCart = await _applicationDbContext.ShopCartData.Where(shopCart => shopCart.User == user).FirstOrDefaultAsync();

        if (shopCart is null) {
            return new List<ProductModel>();
        }
        
        return shopCart?.Product;
    }

    [HttpPost]
    public async Task<IActionResult> RemoveProductsFromCart(int id)
    {
        var user = User.Identity?.Name ?? string.Empty;

        var shopCart = await _applicationDbContext.ShopCartData.Where(shopCart => shopCart.User == user).FirstOrDefaultAsync();

        shopCart?.Product.RemoveAll(product => product.Id == id);

        await _applicationDbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddProductToCart(int id)
    {
        var user = User.Identity?.Name ?? string.Empty;

        var shopCart = await _applicationDbContext.ShopCartData.Where(shopCart => shopCart.User == user).FirstOrDefaultAsync();

        if (shopCart is null)
        {
            _applicationDbContext.Add(new ShopCartModel()
            {
                User = user,
                Product = [new ProductModel()
                {
                    Id = id
                }]
            });
        }
        else
        {
            shopCart.Product.Add(new ProductModel() { Id = id });
        }

        await _applicationDbContext.SaveChangesAsync();

        return Ok();
    }
}