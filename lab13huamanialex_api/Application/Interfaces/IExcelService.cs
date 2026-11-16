using lab13huamanialex_api.Application.DTOs;

namespace lab13huamanialex_api.Application.Interfaces;

public interface IExcelService
{
    byte[] GenerarReporteClientes(IReadOnlyList<ClienteReporteDto> clientes);
    byte[] GenerarReporteVentas(IReadOnlyList<VentaReporteDto> ventas);
    byte[] GenerarReporteProductos(IReadOnlyList<ProductoReporteDto> productos);
    byte[] GenerarReporteDetallesPedidos(IReadOnlyList<DetallePedidoReporteDto> detalles);
}
