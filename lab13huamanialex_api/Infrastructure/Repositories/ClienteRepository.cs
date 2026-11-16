using lab13huamanialex_api.Application.DTOs;
using lab13huamanialex_api.Domain.Interfaces;
using lab13huamanialex_api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace lab13huamanialex_api.Infrastructure.Repositories;

public sealed class ClienteRepository(LinQExampleDbContext context) : IClienteRepository
{
    public async Task<IReadOnlyList<ClienteReporteDto>> ObtenerClientesAsync(CancellationToken cancellationToken)
    {
        return await context.Clients.AsNoTracking()
            .OrderBy(c => c.ClientId)
            .Select(c => new ClienteReporteDto(c.ClientId, c.Name, c.Email))
            .ToListAsync(cancellationToken);
    }
}
