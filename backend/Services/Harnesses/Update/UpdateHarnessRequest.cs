using Audacia.Commands;
using MediatR;
using Domain.Entities;

namespace Services.Harnesses.Update;

/// <summary>
/// A request to update a harness.
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
/// <param name="Size"></param>
/// <param name="Sex"></param>
public record UpdateHarnessRequest(int Id, int? ToughTag, string? Brand, int? Model, DateTimeOffset? DateOfPurchase, DateTimeOffset? ManufacturerExpiry, DateTimeOffset? LastInspection, DateTimeOffset? NextInspection, Guid? InspectedBy, Size? Size, Sex? Sex) : IRequest<CommandResult>
{
}
