using Audacia.Commands;
using MediatR;

namespace Services.Helmets.Add;

/// <summary>
/// The interface for the service that adds a helmet.
/// </summary>
public interface IAddHelmetService : IRequestHandler<AddHelmetRequest, CommandResult>
{
}
