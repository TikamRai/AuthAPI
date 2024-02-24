using Auth.models;

namespace Auth.test;

public class ShopCartUTest {
    [Fact]
    public void Test1_EmptyCart() {
        var cart = new ShopCartModel();

        Assert.Empty(cart.Product);
    }

    [Fact]
    public void Test2_Id() {
        var cart = new ShopCartModel {
            Id = 5
        };

        Assert.Equal(5, cart.Id);
    }

    [Fact]
    public void Test3_User() {
        var cart = new ShopCartModel {
            User = "Elon Musk"
        };

        Assert.Equal("Elon Musk", cart.User);
    }

    [Fact]
    public void Test4_AddAndRemoveProduct() {
        var cart = new ShopCartModel();
        var iphone = new ProductModel { Id = 1, Name = "iPhone 15 Pro Max" };
        var samsung = new ProductModel { Id = 2, Name = "Samsung Galaxy S24 Ultra" };

        cart.Product.Add(iphone);
        cart.Product.Add(samsung);
        cart.Product.Remove(iphone);

        Assert.Single(cart.Product);
        Assert.Contains(samsung, cart.Product);
    }
}