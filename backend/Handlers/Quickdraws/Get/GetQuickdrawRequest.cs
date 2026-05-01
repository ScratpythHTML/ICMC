using MediatR;
using Audacia.Commands;

namespace Handlers.Quickdraws.Get;

/// <summary>
/// A request to get a quickdraw by ID.
/// </summary>
/// <param name="Id"></param>
public record GetQuickdrawRequest(int Id) : IRequest<CommandResult<QuickdrawDto>>;
