using Audacia.Commands;
using MediatR;

namespace Handlers.Carabiners.Add;

/// <summary>
/// The interface for the handler that adds a carabiner.
/// </summary>
public interface IAddCarabinerHandler : IRequestHandler<AddCarabinerRequest, CommandResult>
{
}
