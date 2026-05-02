using Audacia.Commands;
using MediatR;

namespace Services.Helmets.Get;

/// <summary>
/// The inferface for the service that gets a helmet.
/// </summary>
public interface IGetHelmetService : IRequestHandler<GetHelmetRequest, CommandResult<HelmetDto>>
{
}
