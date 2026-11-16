using lab13huamanialex_api.Application.DTOs;

namespace lab13huamanialex_api.Domain.Interfaces;

public interface IVentaRepository
{
    Task<IReadOnlyList<VentaReporteDto>> ObtenerVentasAsync(CancellationToken cancellationToken);
}
