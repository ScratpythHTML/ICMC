using MediatR;
using Audacia.Commands;

namespace Services.Helmets.Get;

/// <summary>
/// A request to get a helmet by ID.
/// </summary>
/// <param name="Id"></param>
public record GetHelmetRequest(int Id) : IRequest<CommandResult<HelmetDto>>;
