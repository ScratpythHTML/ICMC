using Audacia.Commands;
using MediatR;

namespace Handlers.Crashpads.Update;

/// <summary>
/// The interface for the handler that updates a crashpad.
/// </summary>
public interface IUpdateCrashpadHandler : IRequestHandler<UpdateCrashpadRequest, CommandResult>
{
}
