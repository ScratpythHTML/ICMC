using Audacia.Commands;
using MediatR;

namespace Services.GearItems.Update;

/// <summary>
/// The interface for the service that updates a gear item.
/// </summary>
public interface IUpdateGearItemService : IRequestHandler<UpdateGearItemRequest, CommandResult>
{
}