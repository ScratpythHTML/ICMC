using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.Ropes.Get;

/// <summary>
/// The empty request for getting all ropes.
/// </summary>
public record GetRopesRequest(StorageLocation storageLocation) : IRequest<CommandResult<RopeDto[]>>;