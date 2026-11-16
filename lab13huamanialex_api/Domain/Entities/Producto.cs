namespace lab13huamanialex_api.Domain.Entities;

public sealed class Producto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public List<DetallePedido> OrderDetails { get; set; } = new();
}
