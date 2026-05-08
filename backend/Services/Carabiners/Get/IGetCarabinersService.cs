using Audacia.Commands;
using MediatR;

namespace Services.Carabiners.Get;

/// <summary>
/// Interface for the service that gets carabiners.
/// </summary>
public interface IGetCarabinersService : IRequestHandler<GetCarabinersRequest, CommandResult<CarabinerDto[]>>;