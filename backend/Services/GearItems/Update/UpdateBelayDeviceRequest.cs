using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.GearItems.Update;

/// <summary>
/// 
/// </summary>
public record UpdateGearItemRequest(
    string? Brand,
    DateTimeOffset? DateOfPurchase,
    GearCategory? GearCategory,
    int Id,
    int? InspectedBy,
    DateTimeOffset? LastInspection,
    int? Length,
    int? LentBy,
    DateTimeOffset? LentDate,
    int? LentTo,
    DateTimeOffset? ManufacturerExpiry,
    string? Model,
    DateTimeOffset? NextInspection,
    DateTimeOffset? ReturnedDate,
    Sex? Sex,
    Size? Size,
    StorageLocation? StorageLocation,
    int? ToughTag
) : IRequest<CommandResult>;