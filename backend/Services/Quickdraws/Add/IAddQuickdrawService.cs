using Audacia.Commands;
using MediatR;

namespace Services.Quickdraws.Add;

/// <summary>
/// The interface for the service that adds a quickdraw.
/// </summary>
public interface IAddQuickdrawService : IRequestHandler<AddQuickdrawRequest, CommandResult>
{
}
