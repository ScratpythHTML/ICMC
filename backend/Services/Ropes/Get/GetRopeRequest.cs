using MediatR;
using Audacia.Commands;

namespace Services.Ropes.Get;

/// <summary>
/// A request to get a rope by ID.
/// </summary>
/// <param name="Id"></param>
public record GetRopeRequest(int Id) : IRequest<CommandResult<RopeDto>>;
