using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
namespace Services.GearItems.Add;

/// <summary>
/// The service that adds a gear item.
/// </summary>
public class AddGearItemService : IAddGearItemService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public AddGearItemService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles adding a gear item.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(AddGearItemRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var gearItem = new GearItem
        {
            Brand = request.Brand,
            DateOfPurchase = request.DateOfPurchase,
            GearCategory = request.GearCategory,
            InspectedBy = request.InspectedBy,
            LastInspection = request.LastInspection,
            Length = request.Length,
            LentBy = request.LentBy,
            LentDate = request.LentDate,
            LentTo = request.LentTo,
            ManufacturerExpiry = request.ManufacturerExpiry,
            Model = request.Model,
            NextInspection = request.NextInspection,
            ReturnedDate = request.ReturnedDate,
            Sex = request.Sex,
            Size = request.Size,
            StorageLocation = request.StorageLocation,
            ToughTag = request.ToughTag
        };

        _context.GearItems.Add(gearItem);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }

}