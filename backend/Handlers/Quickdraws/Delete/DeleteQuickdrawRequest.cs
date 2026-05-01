using Audacia.Commands;
using MediatR;

namespace Handlers.Quickdraws.Delete;

/// <summary>
/// A request to delete a quickdraw by ID.
/// </summary>
/// <param name="Id"></param>
public record DeleteQuickdrawRequest(int Id) : IRequest<CommandResult>;
