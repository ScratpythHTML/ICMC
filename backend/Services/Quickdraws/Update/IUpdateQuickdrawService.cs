using Audacia.Commands;
using MediatR;

namespace Services.Quickdraws.Update;

/// <summary>
/// The interface for the service that updates a quickdraw.
/// </summary>
public interface IUpdateQuickdrawService : IRequestHandler<UpdateQuickdrawRequest, CommandResult>
{
}
