using lab13huamanialex_api.Application.DTOs;
using lab13huamanialex_api.Domain.Interfaces;
using lab13huamanialex_api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace lab13huamanialex_api.Infrastructure.Repositories;

public sealed class VentaRepository(LinQExampleDbContext context) : IVentaRepository
{
    public async Task<IReadOnlyList<VentaReporteDto>> ObtenerVentasAsync(CancellationToken cancellationToken)
    {
        return await context.OrderDetails.AsNoTracking()
            .OrderBy(d => d.OrderId).ThenBy(d => d.OrderDetailId)
            .Select(d => new VentaReporteDto(
                d.OrderId,
                d.Order.Client.Name,
                d.Order.OrderDate,
                d.Product.Name,
                d.Quantity,
                d.Product.Price,
                d.Quantity * d.Product.Price))
            .ToListAsync(cancellationToken);
    }
}
