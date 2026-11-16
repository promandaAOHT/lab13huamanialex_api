using lab13huamanialex_api.Application.DTOs;
namespace lab13huamanialex_api.Domain.Interfaces;
public interface IDetallePedidoRepository
{
    Task<IReadOnlyList<DetallePedidoReporteDto>> ObtenerDetallesAsync(CancellationToken cancellationToken);
}
