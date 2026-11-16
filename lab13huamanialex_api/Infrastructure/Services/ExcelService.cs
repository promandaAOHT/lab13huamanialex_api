using ClosedXML.Excel;
using lab13huamanialex_api.Application.DTOs;
using lab13huamanialex_api.Application.Interfaces;

namespace lab13huamanialex_api.Infrastructure.Services;

public sealed class ExcelService : IExcelService
{
    public byte[] GenerarReporteClientes(IReadOnlyList<ClienteReporteDto> clientes)
    {
        using var workbook = new XLWorkbook();
        var hoja = workbook.Worksheets.Add("Clientes");
        hoja.Cell(1, 1).Value = "ID";
        hoja.Cell(1, 2).Value = "Nombre";
        hoja.Cell(1, 3).Value = "Email";

        for (int i = 0; i < clientes.Count; i++)
        {
            var c = clientes[i];
            hoja.Cell(i + 2, 1).Value = c.Id;
            hoja.Cell(i + 2, 2).Value = c.Nombre;
            hoja.Cell(i + 2, 3).Value = c.Email;
        }

        DarFormato(hoja, 3, clientes.Count + 1);
        return ABytes(workbook);
    }

    public byte[] GenerarReporteVentas(IReadOnlyList<VentaReporteDto> ventas)
    {
        using var workbook = new XLWorkbook();
        var hoja = workbook.Worksheets.Add("Ventas");
        string[] encabezados =
        {
            "Pedido", "Cliente", "Fecha", "Producto", "Cantidad", "Precio unitario", "Subtotal"
        };
        for (int i = 0; i < encabezados.Length; i++)
            hoja.Cell(1, i + 1).Value = encabezados[i];

        for (int i = 0; i < ventas.Count; i++)
        {
            var v = ventas[i];
            int fila = i + 2;
            hoja.Cell(fila, 1).Value = v.PedidoId;
            hoja.Cell(fila, 2).Value = v.Cliente;
            hoja.Cell(fila, 3).Value = v.FechaPedido;
            hoja.Cell(fila, 4).Value = v.Producto;
            hoja.Cell(fila, 5).Value = v.Cantidad;
            hoja.Cell(fila, 6).Value = v.PrecioUnitario;
            hoja.Cell(fila, 7).Value = v.Subtotal;
        }

        if (ventas.Count > 0)
        {
            hoja.Range(2, 3, ventas.Count + 1, 3).Style.DateFormat.Format = "dd/mm/yyyy";
            hoja.Range(2, 6, ventas.Count + 1, 7).Style.NumberFormat.Format = "#,##0.00";
        }
        DarFormato(hoja, 7, ventas.Count + 1);
        return ABytes(workbook);
    }

    public byte[] GenerarReporteProductos(IReadOnlyList<ProductoReporteDto> productos)
    {
        using var workbook = new XLWorkbook();
        var hoja = workbook.Worksheets.Add("Productos");
        string[] encabezados = { "ID", "Nombre", "Descripción", "Precio" };
        for (int i = 0; i < encabezados.Length; i++) hoja.Cell(1, i + 1).Value = encabezados[i];
        for (int i = 0; i < productos.Count; i++)
        {
            var p = productos[i]; var fila = i + 2;
            hoja.Cell(fila, 1).Value = p.Id;
            hoja.Cell(fila, 2).Value = p.Nombre;
            hoja.Cell(fila, 3).Value = p.Descripcion ?? "";
            hoja.Cell(fila, 4).Value = p.Precio;
        }
        if (productos.Count > 0)
            hoja.Range(2, 4, productos.Count + 1, 4).Style.NumberFormat.Format = "#,##0.00";
        DarFormato(hoja, 4, productos.Count + 1);
        return ABytes(workbook);
    }

    public byte[] GenerarReporteDetallesPedidos(IReadOnlyList<DetallePedidoReporteDto> detalles)
    {
        using var workbook = new XLWorkbook();
        var hoja = workbook.Worksheets.Add("DetallesPedidos");
        string[] encabezados = { "ID Detalle", "ID Pedido", "ID Producto", "Producto", "Cantidad", "Precio unitario", "Subtotal" };
        for (int i = 0; i < encabezados.Length; i++) hoja.Cell(1, i + 1).Value = encabezados[i];
        for (int i = 0; i < detalles.Count; i++)
        {
            var d = detalles[i]; var fila = i + 2;
            hoja.Cell(fila, 1).Value = d.Id;
            hoja.Cell(fila, 2).Value = d.PedidoId;
            hoja.Cell(fila, 3).Value = d.ProductoId;
            hoja.Cell(fila, 4).Value = d.Producto;
            hoja.Cell(fila, 5).Value = d.Cantidad;
            hoja.Cell(fila, 6).Value = d.PrecioUnitario;
            hoja.Cell(fila, 7).Value = d.Subtotal;
        }
        if (detalles.Count > 0)
            hoja.Range(2, 6, detalles.Count + 1, 7).Style.NumberFormat.Format = "#,##0.00";
        DarFormato(hoja, 7, detalles.Count + 1);
        return ABytes(workbook);
    }

    private static void DarFormato(IXLWorksheet hoja, int columnas, int filas)
    {
        var encabezado = hoja.Range(1, 1, 1, columnas);
        encabezado.Style.Font.Bold = true;
        encabezado.Style.Fill.BackgroundColor = XLColor.Cyan;
        encabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        if (filas > 1)
            hoja.Range(1, 1, filas, columnas).CreateTable();
        hoja.Columns(1, columnas).AdjustToContents();
    }

    private static byte[] ABytes(XLWorkbook workbook)
    {
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
}
