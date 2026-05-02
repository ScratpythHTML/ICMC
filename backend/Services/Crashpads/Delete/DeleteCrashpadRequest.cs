using Audacia.Commands;
using MediatR;

namespace Services.Crashpads.Delete;

/// <summary>
/// A request to delete a crashpad by ID.
/// </summary>
/// <param name="Id"></param>
public record DeleteCrashpadRequest(int Id) : IRequest<CommandResult>;
