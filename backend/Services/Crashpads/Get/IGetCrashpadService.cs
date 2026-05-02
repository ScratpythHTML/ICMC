using Audacia.Commands;
using MediatR;

namespace Services.Crashpads.Get;

/// <summary>
/// The inferface for the service that gets a crashpad.
/// </summary>
public interface IGetCrashpadService : IRequestHandler<GetCrashpadRequest, CommandResult<CrashpadDto>>
{
}
