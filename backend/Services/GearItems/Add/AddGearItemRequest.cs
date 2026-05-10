using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.GearItems.Add;

/// <summary>
/// A request to add a gear item.
/// </summary>
/// <param name="Brand"></param>
/// <param name="DateOfPurchase"></param>
/// <param name="GearCategory"></param>
/// <param name="InspectedBy"></param>
/// <param name="LastInspection"></param>
/// <param name="Length"></param>
/// <param name="LentBy"></param>
/// <param name="LentDate"></param>
/// <param name="LentTo"></param>
/// <param name="ManufacturerExpiry"></param>
/// <param name="Model"></param>
/// <param name="NextInspection"></param>
/// <param name="ReturnedDate"></param>
/// <param name="Sex"></param>
/// <param name="Size"></param>
/// <param name="StorageLocation"></param>
/// <param name="ToughTag"></param>
public record AddGearItemRequest(
    int ToughTag,
    string? Brand,
    string? Model,
    DateTimeOffset? DateOfPurchase,
    DateTimeOffset? ManufacturerExpiry,
    DateTimeOffset? LastInspection,
    DateTimeOffset? NextInspection,
    string? InspectedBy,
    string? LentTo,
    string? LentBy,
    DateTimeOffset? LentDate,
    DateTimeOffset? ReturnedDate,
    StorageLocation StorageLocation,
    Size? Size,
    Sex? Sex,
    int? Length,
    GearCategory GearCategory
) : IRequest<CommandResult>;
