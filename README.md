# Laboratorio 13 — Parte 6 (.NET 10 + MySQL + ClosedXML)

API REST que exporta **dos reportes Excel** desde la base de datos MySQL `LINQExample`.

## Requisitos

- .NET SDK 10 y Rider o Visual Studio.
- MySQL Server funcionando (MySQL Workbench es el cliente de administración).
- Base de datos `LINQExample` con las tablas `Clients`, `Products`, `Orders`, `OrderDetails`.

## Instrucciones

1. En MySQL Workbench ejecuta `database/LINQExample_MySQL.sql` **solo si la base de datos y sus tablas aún no existen**. El script no elimina datos, pero no debe ejecutarse dos veces porque las tablas ya existirían.
2. Abre `lab13huamanialex_api.csproj` desde Rider.
3. Configura la cadena de conexión. Para una prueba local puedes editar `appsettings.json` y reemplazar `CAMBIAR_CONTRASENA`. **No subas contraseñas reales a Git.** Mejor utiliza secretos de usuario:
   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:MySql" "server=localhost;port=3306;database=LINQExample;user=root;password=TU_CLAVE;"
   ```
4. En la terminal de Rider, dentro de la carpeta del proyecto:
   ```bash
   dotnet restore
   dotnet run --launch-profile http
   ```
5. Abre `http://localhost:5187/swagger`.
6. Prueba `GET /api/reportes/clientes` y `GET /api/reportes/ventas`. En el navegador puedes ir directamente a:
   - http://localhost:5187/api/reportes/clientes
   - http://localhost:5187/api/reportes/ventas

Los archivos descargados se llaman `reporte_clientes.xlsx` y `reporte_ventas.xlsx`.

## Arquitectura

- `Domain/Entities`: entidades que corresponden a tablas MySQL.
- `Domain/Interfaces`: contratos de repositorios.
- `Infrastructure/Persistence`: contexto EF Core, mapeo de tablas y relaciones.
- `Infrastructure/Repositories`: consultas a MySQL (sin lógica de Excel).
- `Application/DTOs`: proyecciones de datos para los reportes.
- `Application/Queries`: casos de uso de lectura (estilo CQRS). **Primero consultan el repositorio y después entregan el listado al servicio**.
- `Application/Interfaces`: contrato del servicio Excel.
- `Infrastructure/Services`: implementación ClosedXML que convierte listas a archivos `.xlsx`.
- `Controllers`: endpoints REST para descargar los reportes.

Este ejercicio utiliza el lado **Query** de CQRS, sin comandos de escritura, porque los reportes solo consultan datos. No usa MediatR porque no es necesario para demostrar la separación de responsabilidades.

## Nota sobre versiones

El proyecto apunta a `net10.0` y usa Pomelo EF Core 9.0.0 (EF Core 9) y Swashbuckle. EF Core 9 puede ejecutarse en .NET 10; no es obligatorio que la versión mayor de cada biblioteca coincida con la del runtime. La restauración depende de que NuGet esté disponible.

## Problemas frecuentes

- **Access denied for user**: comprueba usuario y contraseña.
- **Unknown database**: ejecuta el SQL en Workbench y verifica que `LINQExample` exista.
- **Unable to connect**: verifica que MySQL Server esté iniciado y el puerto sea 3306.
- **Error de certificados HTTPS**: utiliza el perfil `http` para la prueba local.
- **Paquetes NuGet**: comprueba la conexión a internet y ejecuta `dotnet restore`.

## Evidencias sugeridas

Captura de las cuatro tablas en Workbench, estructura del proyecto en Rider, Swagger mostrando los dos endpoints y ambos Excel abiertos.
