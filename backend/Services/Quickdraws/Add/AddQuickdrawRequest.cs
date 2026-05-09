using Audacia.Commands;
using MediatR;


namespace Services.Quickdraws.Add;

/// <summary>
/// A request to add a quickdraw.
/// </summary>
/// <param name="ToughTag"></param>
/// <param name="Brand"></param>
/// <param name="Model"></param>
/// <param name="DateOfPurchase"></param>
/// <param name="ManufacturerExpiry"></param>
/// <param name="LastInspection"></param>
/// <param name="NextInspection"></param>
/// <param name="InspectedBy"></param>
public record AddQuickdrawRequest(int? ToughTag, string? Brand, int? Model, DateTimeOffset? DateOfPurchase, DateTimeOffset? ManufacturerExpiry, DateTimeOffset? LastInspection, DateTimeOffset? NextInspection, int? InspectedBy) : IRequest<CommandResult>
{
}
