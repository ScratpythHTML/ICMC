using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.Harnesses.Get;

/// <summary>
/// The empty request for getting all harnesses.
/// </summary>
public record GetHarnessesRequest(StorageLocation storageLocation) : IRequest<CommandResult<HarnessDto[]>>;