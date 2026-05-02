using Audacia.Commands;
using MediatR;

namespace Services.Crashpads.Update;

/// <summary>
/// The interface for the service that updates a crashpad.
/// </summary>
public interface IUpdateCrashpadService : IRequestHandler<UpdateCrashpadRequest, CommandResult>
{
}
