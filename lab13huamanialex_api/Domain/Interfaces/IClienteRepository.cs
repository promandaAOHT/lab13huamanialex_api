using lab13huamanialex_api.Application.DTOs;

namespace lab13huamanialex_api.Domain.Interfaces;

public interface IClienteRepository
{
    Task<IReadOnlyList<ClienteReporteDto>> ObtenerClientesAsync(CancellationToken cancellationToken);
}
