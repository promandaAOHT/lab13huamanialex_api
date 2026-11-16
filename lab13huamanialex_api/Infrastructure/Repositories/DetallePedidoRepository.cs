using lab13huamanialex_api.Application.DTOs;
using lab13huamanialex_api.Domain.Interfaces;
using lab13huamanialex_api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace lab13huamanialex_api.Infrastructure.Repositories;
public sealed class DetallePedidoRepository(LinQExampleDbContext context) : IDetallePedidoRepository
{
    public async Task<IReadOnlyList<DetallePedidoReporteDto>> ObtenerDetallesAsync(CancellationToken cancellationToken)
    {
        return await context.OrderDetails.AsNoTracking().OrderBy(d => d.OrderDetailId)
            .Select(d => new DetallePedidoReporteDto(d.OrderDetailId, d.OrderId, d.ProductId,
                d.Product.Name, d.Quantity, d.Product.Price, d.Quantity * d.Product.Price))
            .ToListAsync(cancellationToken);
    }
}
