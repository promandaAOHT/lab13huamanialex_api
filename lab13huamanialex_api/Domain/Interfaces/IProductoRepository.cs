using lab13huamanialex_api.Application.DTOs;
namespace lab13huamanialex_api.Domain.Interfaces;
public interface IProductoRepository
{
    Task<IReadOnlyList<ProductoReporteDto>> ObtenerProductosAsync(CancellationToken cancellationToken);
}
