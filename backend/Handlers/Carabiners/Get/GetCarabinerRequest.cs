using MediatR;
using Audacia.Commands;

namespace Handlers.Carabiners.Get;

/// <summary>
/// A request to get a carabiner by ID.
/// </summary>
/// <param name="Id"></param>
public record GetCarabinerRequest(int Id) : IRequest<CommandResult<CarabinerDto>>;
