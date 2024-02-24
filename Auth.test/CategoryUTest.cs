using Auth.models;

namespace Auth.test;

public class CategoryUTest {
    [Fact]
    public void Test1_DefaultValues() {
        var category = new CategoryModel();

        Assert.Equal(0, category.Id);
        Assert.Null(category.Description);
    }

    [Fact]
    public void Test2_DescriptionNullable() {

        var category = new CategoryModel {
            Description = null
        };

        Assert.Null(category.Description);
    }

    [Fact]
    public void Test3_CorrectId() {
        var category = new CategoryModel {
            Id = 1
        };

        Assert.Equal(1, category.Id);
    }

    [Fact]
    public void Test3_CorrectDescription() {
        var category = new CategoryModel {
            Description = "Smartphones"
        };

        Assert.Equal("Smartphones", category.Description);
    }
}