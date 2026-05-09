using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.GearItems.Get;

/// <summary>
/// The service that gets all belay devices.
/// </summary>
public class GetGearItemsService : IGetGearItemsService
{
    private readonly DatabaseContext _context;
    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public GetGearItemsService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that gets all belay devices.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<GearItemDto[]>> Handle(GetGearItemsRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var result = await _context.GearItems.Select(gi => new GearItemDto
        {
            Brand = gi.Brand,
            DateOfPurchase = gi.DateOfPurchase,
            GearCategory = request.gearCategory,
            Id = gi.Id,
            InspectedBy = gi.InspectedBy,
            LastInspection = gi.LastInspection,
            Length = gi.Length,
            LentBy = gi.LentBy,
            LentDate = gi.LentDate,
            LentTo = gi.LentTo,
            ManufacturerExpiry = gi.ManufacturerExpiry,
            Model = gi.Model,
            NextInspection = gi.NextInspection,
            ReturnedDate = gi.ReturnedDate,
            Sex = gi.Sex,
            Size = gi.Size,
            StorageLocation = request.storageLocation,
            ToughTag = gi.ToughTag,

        }).ToArrayAsync(cancellationToken);

        if (result == null)
        {
            return CommandResult.Failure<GearItemDto[]>("No gear items found");
        }

        return CommandResult.WithResult(result);
    }
}