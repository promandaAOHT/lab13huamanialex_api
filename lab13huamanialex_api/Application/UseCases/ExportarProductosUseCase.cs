using lab13huamanialex_api.Application.Interfaces;
using lab13huamanialex_api.Domain.Interfaces;

namespace lab13huamanialex_api.Application.UseCases;

// Caso de uso: consulta al repositorio y delega la creación del Excel al servicio.
public sealed class ExportarProductosUseCase(
    IProductoRepository repository,
    IExcelService excelService)
{
    public async Task<byte[]> EjecutarAsync(CancellationToken cancellationToken = default)
    {
        var productos = await repository.ObtenerProductosAsync(cancellationToken);
        return excelService.GenerarReporteProductos(productos);
    }
}
