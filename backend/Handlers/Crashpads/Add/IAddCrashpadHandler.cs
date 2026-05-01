using Audacia.Commands;
using MediatR;

namespace Handlers.Crashpads.Add;

/// <summary>
/// The interface for the handler that adds a crashpad.
/// </summary>
public interface IAddCrashpadHandler : IRequestHandler<AddCrashpadRequest, CommandResult>
{
}
