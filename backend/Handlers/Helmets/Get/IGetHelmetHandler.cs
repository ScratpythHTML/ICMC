using MediatR;
using Audacia.Commands;

namespace Handlers.Helmets.Get;

/// <summary>
/// The inferface for the handler that gets a helmet.
/// </summary>
public interface IGetHelmetHandler : IRequestHandler<GetHelmetRequest, CommandResult<HelmetDto>>
{
}
