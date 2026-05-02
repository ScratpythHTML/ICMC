using Audacia.Commands;
using MediatR;

namespace Services.Carabiners.Get;

/// <summary>
/// The inferface for the service that gets a carabiner.
/// </summary>
public interface IGetCarabinerService : IRequestHandler<GetCarabinerRequest, CommandResult<CarabinerDto>>
{
}
