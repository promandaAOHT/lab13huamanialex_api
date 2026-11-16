using lab13huamanialex_api.Application.DTOs;
using lab13huamanialex_api.Domain.Interfaces;
using lab13huamanialex_api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace lab13huamanialex_api.Infrastructure.Repositories;
public sealed class ProductoRepository(LinQExampleDbContext context) : IProductoRepository
{
    public async Task<IReadOnlyList<ProductoReporteDto>> ObtenerProductosAsync(CancellationToken cancellationToken)
    {
        return await context.Products.AsNoTracking().OrderBy(p => p.ProductId)
            .Select(p => new ProductoReporteDto(p.ProductId, p.Name, p.Description, p.Price))
            .ToListAsync(cancellationToken);
    }
}
