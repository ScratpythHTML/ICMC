using MediatR;
using Audacia.Commands;

namespace Handlers.Quickdraws.Get;

/// <summary>
/// The inferface for the handler that gets a quickdraw.
/// </summary>
public interface IGetQuickdrawHandler : IRequestHandler<GetQuickdrawRequest, CommandResult<QuickdrawDto>>
{
}
