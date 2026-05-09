using Audacia.Commands;
using MediatR;

namespace Services.GearItems.Add;

/// <summary>
/// The interface for the service that adds a gear item.
/// </summary>
public interface IAddGearItemService : IRequestHandler<AddGearItemRequest, CommandResult>
{
}