using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.Helmets.Get;

/// <summary>
/// The empty request for getting all helmets.
/// </summary>
public record GetHelmetsRequest(StorageLocation storageLocation) : IRequest<CommandResult<HelmetDto[]>>;