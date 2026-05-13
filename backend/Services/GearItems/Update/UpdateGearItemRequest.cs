using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.GearItems.Update;

/// <summary>
/// The request to update a gear item.
/// </summary>
/// <param name="Id"></param>
/// <param name="Brand"></param>
/// <param name="DateOfPurchase"></param>
/// <param name="ExpectedReturnDate"></param>
/// <param name="GearCategory"></param>
/// <param name="ImageUrl"></param>
/// <param name="InspectedByUserId"></param>
/// <param name="LastInspection"></param>
/// <param name="LentByUserId"></param>
/// <param name="LentDate"></param>
/// <param name="LentToUserId"></param>
/// <param name="Length"></param>
/// <param name="ManufacturerExpiry"></param>
/// <param name="Model"></param>
/// <param name="NextInspection"></param>
/// <param name="ReturnedDate"></param>
/// <param name="Sex"></param>
/// <param name="Size"></param>
/// <param name="StorageLocation"></param>
/// <param name="ToughTag"></param>
public record UpdateGearItemRequest(
    int Id,
    string? Brand,
    DateTimeOffset? DateOfPurchase,
    DateTimeOffset? ExpectedReturnDate,
    GearCategory? GearCategory,
    string? ImageUrl,
    int? InspectedByUserId,
    DateTimeOffset? LastInspection,
    int? LentByUserId,
    DateTimeOffset? LentDate,
    int? LentToUserId,
    int? Length,
    DateTimeOffset? ManufacturerExpiry,
    string? Model,
    DateTimeOffset? NextInspection,
    DateTimeOffset? ReturnedDate,
    Sex? Sex,
    Size? Size,
    StorageLocation? StorageLocation,
    string? ToughTag
) : IRequest<CommandResult>;