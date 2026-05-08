using Audacia.Commands;
using MediatR;

namespace Services.Crashpads.Get;

/// <summary>
/// Interface for the service that gets crashpads.
/// </summary>
public interface IGetCrashpadsService : IRequestHandler<GetCrashpadsRequest, CommandResult<CrashpadDto[]>>;