namespace lab13huamanialex_api.Domain.Entities;

public sealed class Pedido
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; }
    public Cliente Client { get; set; } = null!;
    public List<DetallePedido> OrderDetails { get; set; } = new();
}
