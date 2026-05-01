using MediatR;
using Audacia.Commands;

namespace Handlers.Crashpads.Get;

/// <summary>
/// A request to get a crashpad by ID.
/// </summary>
/// <param name="Id"></param>
public record GetCrashpadRequest(int Id) : IRequest<CommandResult<CrashpadDto>>;
