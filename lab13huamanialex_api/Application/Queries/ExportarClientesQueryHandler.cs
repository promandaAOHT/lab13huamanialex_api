using lab13huamanialex_api.Application.UseCases;

namespace lab13huamanialex_api.Application.Queries;

// CQRS (lectura): delega la ejecución al caso de uso correspondiente.
public sealed class ExportarClientesQueryHandler(ExportarClientesUseCase useCase)
{
    public Task<byte[]> HandleAsync(CancellationToken cancellationToken = default)
        => useCase.EjecutarAsync(cancellationToken);
}
