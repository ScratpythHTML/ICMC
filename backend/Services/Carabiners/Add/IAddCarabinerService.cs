using Audacia.Commands;
using MediatR;

namespace Services.Carabiners.Add;

/// <summary>
/// The interface for the service that adds a carabiner.
/// </summary>
public interface IAddCarabinerService : IRequestHandler<AddCarabinerRequest, CommandResult>
{
}
