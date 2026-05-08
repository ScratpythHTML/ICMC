using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.Crashpads.Get;

/// <summary>
/// The empty request for getting all crashpads.
/// </summary>
public record GetCrashpadsRequest(StorageLocation storageLocation) : IRequest<CommandResult<CrashpadDto[]>>;