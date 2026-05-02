using Audacia.Commands;
using MediatR;

namespace Services.Quickdraws.Get;

/// <summary>
/// The inferface for the service that gets a quickdraw.
/// </summary>
public interface IGetQuickdrawService : IRequestHandler<GetQuickdrawRequest, CommandResult<QuickdrawDto>>
{
}
