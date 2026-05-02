using Audacia.Commands;
using MediatR;

namespace Services.Helmets.Update;

/// <summary>
/// The interface for the service that updates a helmet.
/// </summary>
public interface IUpdateHelmetService : IRequestHandler<UpdateHelmetRequest, CommandResult>
{
}
