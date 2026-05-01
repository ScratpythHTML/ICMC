using Audacia.Commands;
using MediatR;

namespace Handlers.Quickdraws.Update;

/// <summary>
/// The interface for the handler that updates a quickdraw.
/// </summary>
public interface IUpdateQuickdrawHandler : IRequestHandler<UpdateQuickdrawRequest, CommandResult>
{
}
