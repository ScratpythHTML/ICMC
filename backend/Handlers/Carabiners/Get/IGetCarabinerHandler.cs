using MediatR;
using Audacia.Commands;

namespace Handlers.Carabiners.Get;

/// <summary>
/// The inferface for the handler that gets a carabiner.
/// </summary>
public interface IGetCarabinerHandler : IRequestHandler<GetCarabinerRequest, CommandResult<CarabinerDto>>
{
}
