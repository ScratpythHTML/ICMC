using Audacia.Commands;
using MediatR;

namespace Services.Crashpads.Delete;

/// <summary>
/// The interface for the service that deletes a crashpad.
/// </summary>
public interface IDeleteCrashpadService : IRequestHandler<DeleteCrashpadRequest, CommandResult>
{
}
