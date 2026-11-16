using lab13huamanialex_api.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace lab13huamanialex_api.Controllers;

[ApiController]
[Route("api/reportes")]
public sealed class ReportesController(
    ExportarClientesQueryHandler clientesQuery,
    ExportarVentasQueryHandler ventasQuery,
    ExportarProductosQueryHandler productosQuery,
    ExportarDetallesPedidosQueryHandler detallesQuery) : ControllerBase
{
    private const string ExcelMime =
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    [HttpGet("clientes")]
    [Produces(ExcelMime)]
    public async Task<IActionResult> DescargarClientes(CancellationToken cancellationToken)
    {
        var contenido = await clientesQuery.HandleAsync(cancellationToken);
        return File(contenido, ExcelMime, "reporte_clientes.xlsx");
    }

    [HttpGet("ventas")]
    [Produces(ExcelMime)]
    public async Task<IActionResult> DescargarVentas(CancellationToken cancellationToken)
    {
        var contenido = await ventasQuery.HandleAsync(cancellationToken);
        return File(contenido, ExcelMime, "reporte_ventas.xlsx");
    }
    [HttpGet("productos")]
    [Produces(ExcelMime)]
    public async Task<IActionResult> DescargarProductos(CancellationToken cancellationToken)
    {
        var contenido = await productosQuery.HandleAsync(cancellationToken);
        return File(contenido, ExcelMime, "reporte_productos.xlsx");
    }

    [HttpGet("detalles-pedidos")]
    [Produces(ExcelMime)]
    public async Task<IActionResult> DescargarDetallesPedidos(CancellationToken cancellationToken)
    {
        var contenido = await detallesQuery.HandleAsync(cancellationToken);
        return File(contenido, ExcelMime, "reporte_detalles_pedidos.xlsx");
    }
}
