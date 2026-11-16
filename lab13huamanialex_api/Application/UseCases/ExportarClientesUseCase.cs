using lab13huamanialex_api.Application.Interfaces;
using lab13huamanialex_api.Domain.Interfaces;

namespace lab13huamanialex_api.Application.UseCases;

// Caso de uso: consulta al repositorio y delega la creación del Excel al servicio.
public sealed class ExportarClientesUseCase(
    IClienteRepository repository,
    IExcelService excelService)
{
    public async Task<byte[]> EjecutarAsync(CancellationToken cancellationToken = default)
    {
        var clientes = await repository.ObtenerClientesAsync(cancellationToken);
        return excelService.GenerarReporteClientes(clientes);
    }
}
