using lab13huamanialex_api.Application.Interfaces;
using lab13huamanialex_api.Domain.Interfaces;

namespace lab13huamanialex_api.Application.UseCases;

// Caso de uso: consulta al repositorio y delega la creación del Excel al servicio.
public sealed class ExportarDetallesPedidosUseCase(
    IDetallePedidoRepository repository,
    IExcelService excelService)
{
    public async Task<byte[]> EjecutarAsync(CancellationToken cancellationToken = default)
    {
        var detalles = await repository.ObtenerDetallesAsync(cancellationToken);
        return excelService.GenerarReporteDetallesPedidos(detalles);
    }
}
