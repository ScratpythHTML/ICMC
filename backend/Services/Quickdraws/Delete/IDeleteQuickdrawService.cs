using Audacia.Commands;
using MediatR;

namespace Services.Quickdraws.Delete;

/// <summary>
/// The interface for the service that deletes a quickdraw.
/// </summary>
public interface IDeleteQuickdrawService : IRequestHandler<DeleteQuickdrawRequest, CommandResult>
{
}
