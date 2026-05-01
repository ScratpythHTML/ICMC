using Audacia.Commands;
using MediatR;


namespace Handlers.Ropes.Update;

/// <summary>
/// A request to update a rope.
/// </summary>
/// <param name="Id"></param>
/// <param name="ToughTag"></param>
/// <param name="Brand"></param>
/// <param name="Model"></param>
/// <param name="DateOfPurchase"></param>
/// <param name="ManufacturerExpiry"></param>
/// <param name="LastInspection"></param>
/// <param name="NextInspection"></param>
/// <param name="InspectedBy"></param>
/// <param name="Length"></param>
public record UpdateRopeRequest(int Id, int? ToughTag, string? Brand, int? Model, DateTimeOffset? DateOfPurchase, DateTimeOffset? ManufacturerExpiry, DateTimeOffset? LastInspection, DateTimeOffset? NextInspection, Guid? InspectedBy, int? Length) : IRequest<CommandResult>
{
}
