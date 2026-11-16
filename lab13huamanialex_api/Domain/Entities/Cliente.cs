namespace lab13huamanialex_api.Domain.Entities;

public sealed class Cliente
{
    public int ClientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Pedido> Orders { get; set; } = new();
}
