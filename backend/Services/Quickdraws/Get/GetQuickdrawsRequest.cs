using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.Quickdraws.Get;

/// <summary>
/// The empty request for getting all quickdraws.
/// </summary>
public record GetQuickdrawsRequest(StorageLocation storageLocation) : IRequest<CommandResult<QuickdrawDto[]>>;