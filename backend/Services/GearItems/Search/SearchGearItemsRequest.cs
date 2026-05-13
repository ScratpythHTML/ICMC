using Audacia.Commands;
using Domain.Entities;
using MediatR;
using Services.GearItems.Dtos;

namespace Services.GearItems.Search;

/// <summary>
/// Request to search all gear items given search parameters.
/// </summary>
/// <param name="Search"></param>
/// <param name="Brand"></param>
/// <param name="DateOfPurchase"></param>
/// <param name="ExpectedReturnDate"></param>
/// <param name="GearCategory"></param>
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
public record SearchGearItemsRequest(
    string? Search,
    string? Brand,
    DateTimeOffset? DateOfPurchase,
    DateTimeOffset? ExpectedReturnDate,
    GearCategory? GearCategory,
    int? InspectedByUserId,
    DateTimeOffset? LastInspection,
    int? Length,
    DateTimeOffset? LentDate,
    int? LentByUserId,
    int? LentToUserId,
    DateTimeOffset? ManufacturerExpiry,
    string? Model,
    DateTimeOffset? NextInspection,
    DateTimeOffset? ReturnedDate,
    Sex? Sex,
    Size? Size,
    StorageLocation? StorageLocation,
    string? ToughTag
) : IRequest<CommandResult<GearItemDto[]>>;