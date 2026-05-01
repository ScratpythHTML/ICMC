using Audacia.Commands;
using MediatR;

namespace Handlers.Crashpads.Delete;

/// <summary>
/// The interface for the handler that deletes a crashpad.
/// </summary>
public interface IDeleteCrashpadHandler : IRequestHandler<DeleteCrashpadRequest, CommandResult>
{
}
