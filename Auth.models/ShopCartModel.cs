namespace Auth.models;

public class ShopCartModel {
    public int Id { get; set; }
    public string? User { get; set; }
    public List<ProductModel> Product { get; set; } = [];
}