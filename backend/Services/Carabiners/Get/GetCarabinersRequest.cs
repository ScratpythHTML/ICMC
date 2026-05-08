using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.Carabiners.Get;

/// <summary>
/// The empty request for getting all carabiners.
/// </summary>
public record GetCarabinersRequest(StorageLocation storageLocation) : IRequest<CommandResult<CarabinerDto[]>>;