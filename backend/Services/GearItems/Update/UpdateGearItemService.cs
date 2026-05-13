using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.GearItems.Update;

/// <summary>
/// Handles updating a gear item.
/// </summary>
public class UpdateGearItemService : IUpdateGearItemService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public UpdateGearItemService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles updating a gear item.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(UpdateGearItemRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var gearItem = await _context.GearItems
            .FirstOrDefaultAsync(bd => bd.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (gearItem == null)
        {
            return CommandResult.Failure("Gear item not found");
        }

        gearItem.Brand = request.Brand ?? gearItem.Brand;
        gearItem.DateOfPurchase = request.DateOfPurchase ?? gearItem.DateOfPurchase;
        gearItem.ExpectedReturnDate = request.ExpectedReturnDate ?? gearItem.ExpectedReturnDate;
        gearItem.GearCategory = request.GearCategory ?? gearItem.GearCategory;
        gearItem.InspectedByUserId = request.InspectedByUserId ?? gearItem.InspectedByUserId;
        gearItem.ImageUrl = request.ImageUrl ?? gearItem.ImageUrl;
        gearItem.LastInspection = request.LastInspection ?? gearItem.LastInspection;
        gearItem.Length = request.Length ?? gearItem.Length;
        gearItem.LentByUserId = request.LentByUserId ?? gearItem.LentByUserId;
        gearItem.LentDate = request.LentDate ?? gearItem.LentDate;
        gearItem.LentToUserId = request.LentToUserId ?? gearItem.LentToUserId;
        gearItem.ManufacturerExpiry = request.ManufacturerExpiry ?? gearItem.ManufacturerExpiry;
        gearItem.Model = request.Model ?? gearItem.Model;
        gearItem.NextInspection = request.NextInspection ?? gearItem.NextInspection;
        gearItem.ReturnedDate = request.ReturnedDate ?? gearItem.ReturnedDate;
        gearItem.Sex = request.Sex ?? gearItem.Sex;
        gearItem.Size = request.Size ?? gearItem.Size;
        gearItem.StorageLocation = request.StorageLocation ?? gearItem.StorageLocation;
        gearItem.ToughTag = request.ToughTag ?? gearItem.ToughTag;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}