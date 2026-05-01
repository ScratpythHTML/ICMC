using Audacia.Commands;
using MediatR;

namespace Handlers.Quickdraws.Delete;

/// <summary>
/// The interface for the handler that deletes a quickdraw.
/// </summary>
public interface IDeleteQuickdrawHandler : IRequestHandler<DeleteQuickdrawRequest, CommandResult>
{
}
