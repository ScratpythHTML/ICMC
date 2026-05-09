using Audacia.Commands;
using MediatR;

namespace Services.GearItems.Delete;

/// <summary>
/// The interface for the service that deletes a gear item.
/// </summary>
public interface IDeleteGearItemService : IRequestHandler<DeleteGearItemRequest, CommandResult>
{
}