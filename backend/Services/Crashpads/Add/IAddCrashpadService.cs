using Audacia.Commands;
using MediatR;

namespace Services.Crashpads.Add;

/// <summary>
/// The interface for the service that adds a crashpad.
/// </summary>
public interface IAddCrashpadService : IRequestHandler<AddCrashpadRequest, CommandResult>
{
}
