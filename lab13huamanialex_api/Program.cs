using lab13huamanialex_api.Application.UseCases;
using lab13huamanialex_api.Application.Interfaces;
using lab13huamanialex_api.Application.Queries;
using lab13huamanialex_api.Domain.Interfaces;
using lab13huamanialex_api.Infrastructure.Persistence;
using lab13huamanialex_api.Infrastructure.Repositories;
using lab13huamanialex_api.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MySql")
    ?? throw new InvalidOperationException("Falta ConnectionStrings:MySql.");

builder.Services.AddDbContext<LinQExampleDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped<ExportarClientesUseCase>();
builder.Services.AddScoped<ExportarVentasUseCase>();
builder.Services.AddScoped<ExportarProductosUseCase>();
builder.Services.AddScoped<ExportarDetallesPedidosUseCase>();
builder.Services.AddScoped<ExportarClientesQueryHandler>();
builder.Services.AddScoped<ExportarVentasQueryHandler>();
builder.Services.AddScoped<ExportarProductosQueryHandler>();
builder.Services.AddScoped<ExportarDetallesPedidosQueryHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
