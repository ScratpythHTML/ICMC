using Audacia.Commands;
using MediatR;

namespace Handlers.Quickdraws.Add;

/// <summary>
/// The interface for the handler that adds a quickdraw.
/// </summary>
public interface IAddQuickdrawHandler : IRequestHandler<AddQuickdrawRequest, CommandResult>
{
}
