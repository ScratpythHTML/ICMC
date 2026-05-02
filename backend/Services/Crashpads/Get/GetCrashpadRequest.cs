using MediatR;
using Audacia.Commands;

namespace Services.Crashpads.Get;

/// <summary>
/// A request to get a crashpad by ID.
/// </summary>
/// <param name="Id"></param>
public record GetCrashpadRequest(int Id) : IRequest<CommandResult<CrashpadDto>>;
