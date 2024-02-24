using Auth.models;

namespace Auth.test;

public class ProductUTest {
    [Fact]
    public void Test1_SettingProperties() {
        var Category = new CategoryModel {
            Id = 1,
            Description = "Android Smartphone"
        };

        var product = new ProductModel {
            Id = 1,
            Price = 200.25m,
            Name = "Samsung Galaxy S24 Ultra",
            Description = "Latest flagship phone by Samsung",
            Category = Category
        };

        Assert.Equal(1, product.Id);
        Assert.Equal(200.25m, product.Price);
        Assert.Equal("Samsung Galaxy S24 Ultra", product.Name);
        Assert.Equal("Latest flagship phone by Samsung", product.Description);
        Assert.Equal(Category, product.Category);
    }

   [Fact]
   public void Test2_Changes() {
    var product = new ProductModel {
        Id = 1,
        Price = 200.25m,
        Name = "iPhone 15 Pro Max",
        Description = "Latest and greatest from Apple",
        Category = new CategoryModel {
            Id = 2,
            Description = "iOS Smartphone"
        }
    };

    var newCategory = new CategoryModel {
        Id = 3,
        Description = "Tizen Phones"
    };

        product.Id = 3;
        product.Price = 100.25m;
        product.Name = "Nubia N90";
        product.Description = "Smartphone by Nubia";
        product.Category = newCategory;

        Assert.Equal(3, product.Id);
        Assert.Equal(100.25m, product.Price);
        Assert.Equal("Nubia N90", product.Name);
        Assert.Equal("Smartphone by Nubia", product.Description);
        Assert.Equal(newCategory, product.Category);
    }

    [Fact]
    public void Test3_NullValues() {
        var product = new ProductModel {
            Id = 0,
            Price = 0.00m,
            Name = null,
            Description = null,
            Category = new CategoryModel {
                Id = 1,
                Description = "Category is not nullable"
            }
        };

        Assert.Equal(0, product.Id);
        Assert.Equal(0.00m, product.Price);
        Assert.Null(product.Name);
        Assert.Null(product.Description);
        Assert.Equal(product.Category, product.Category);
    }

    [Fact]
    public void Test4_CheckingSameProducts() {
        var category = new CategoryModel {
            Id = 3,
            Description = "Motorola Smartphone"
        };

        var product1 = new ProductModel {
            Id = 4,
            Price = 400.45m,
            Name = "Moto Edge",
            Description = "Smartphone by Motorola",
            Category = category
        };

        var product2 = new ProductModel {
            Id = 4,
            Price = 400.45m,
            Name = "Moto Edge",
            Description = "Smartphone by Motorola",
            Category = category
        };

        Assert.Equal(product1.Id, product2.Id);
        Assert.Equal(product1.Price, product2.Price);
        Assert.Equal(product1.Name, product2.Name);
        Assert.Equal(product1.Description, product2.Description);
        Assert.Equal(product1.Category, product2.Category);
    }
}