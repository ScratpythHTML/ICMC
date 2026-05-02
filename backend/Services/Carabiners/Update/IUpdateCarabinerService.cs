using Audacia.Commands;
using MediatR;

namespace Services.Carabiners.Update;

/// <summary>
/// The interface for the service that updates a carabiner.
/// </summary>
public interface IUpdateCarabinerService : IRequestHandler<UpdateCarabinerRequest, CommandResult>
{
}
