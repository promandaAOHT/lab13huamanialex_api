namespace lab13huamanialex_api.Domain.Entities;

public sealed class DetallePedido
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public Pedido Order { get; set; } = null!;
    public Producto Product { get; set; } = null!;
}
