namespace lab13huamanialex_api.Application.DTOs;
public sealed record DetallePedidoReporteDto(int Id, int PedidoId, int ProductoId, string Producto, int Cantidad, decimal PrecioUnitario, decimal Subtotal);
