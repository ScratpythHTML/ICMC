using Domain.Entities;

namespace Services.GearItems.Dtos;

/// <summary>
/// DTO for a gear item.
/// </summary>
/// <param name="Id"></param>
/// <param name="ToughTag"></param>
/// <param name="Brand"></param>
/// <param name="Model"></param>
/// <param name="DateOfPurchase"></param>
/// <param name="ManufacturerExpiry"></param>
/// <param name="LastInspection"></param>
/// <param name="NextInspection"></param>
/// <param name="InspectedByUserId"></param>
/// <param name="LentToUserId"></param>
/// <param name="LentByUserId"></param>
/// <param name="LentDate"></param>
/// <param name="ReturnedDate"></param>
/// <param name="ExpectedReturnDate"></param>
/// <param name="StorageLocation"></param>
/// <param name="Size"></param>
/// <param name="Sex"></param>
/// <param name="Length"></param>
/// <param name="GearCategory"></param>
/// <param name="ImageUrl"></param>
public record GearItemDto(
    int Id,
    string? Brand,
    DateTimeOffset? DateOfPurchase,
    DateTimeOffset? ExpectedReturnDate,
    GearCategory? GearCategory,
    string? ImageUrl,
    int? InspectedByUserId,
    DateTimeOffset? LastInspection,
    int? Length,
    int? LentByUserId,
    DateTimeOffset? LentDate,
    int? LentToUserId,
    DateTimeOffset? ManufacturerExpiry,
    string? Model,
    DateTimeOffset? NextInspection,
    DateTimeOffset? ReturnedDate,
    Sex? Sex,
    Size? Size,
    StorageLocation? StorageLocation,
    string? ToughTag
);