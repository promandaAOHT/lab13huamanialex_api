namespace lab13huamanialex_api.Application.DTOs;

public sealed record VentaReporteDto(
    int PedidoId, string Cliente, DateTime FechaPedido,
    string Producto, int Cantidad, decimal PrecioUnitario, decimal Subtotal);
