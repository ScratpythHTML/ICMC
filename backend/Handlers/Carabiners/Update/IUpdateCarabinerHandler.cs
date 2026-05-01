using Audacia.Commands;
using MediatR;

namespace Handlers.Carabiners.Update;

/// <summary>
/// The interface for the handler that updates a carabiner.
/// </summary>
public interface IUpdateCarabinerHandler : IRequestHandler<UpdateCarabinerRequest, CommandResult>
{
}
