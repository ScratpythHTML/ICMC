using MediatR;
using Audacia.Commands;

namespace Handlers.Crashpads.Get;

/// <summary>
/// The inferface for the handler that gets a crashpad.
/// </summary>
public interface IGetCrashpadHandler : IRequestHandler<GetCrashpadRequest, CommandResult<CrashpadDto>>
{
}
