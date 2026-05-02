using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Carabiners.Update;

/// <summary>
/// The service for updating a carabiner
/// </summary>
public class UpdateCarabinerService : IUpdateCarabinerService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// Constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public UpdateCarabinerService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles updating a carabiner.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(UpdateCarabinerRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var carabiner = await _context.Carabiners
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (carabiner == null)
        {
            return CommandResult.Failure("Carabiner not found");
        }

        carabiner.Brand = request.Brand ?? carabiner.Brand;
        carabiner.DateOfPurchase = request.DateOfPurchase ?? carabiner.DateOfPurchase;
        carabiner.InspectedBy = request.InspectedBy ?? carabiner.InspectedBy;
        carabiner.LastInspection = request.LastInspection ?? carabiner.LastInspection;
        carabiner.ManufacturerExpiry = request.ManufacturerExpiry ?? carabiner.ManufacturerExpiry;
        carabiner.Model = request.Model ?? carabiner.Model;
        carabiner.NextInspection = request.NextInspection ?? carabiner.NextInspection;
        carabiner.ToughTag = request.ToughTag ?? carabiner.ToughTag;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
