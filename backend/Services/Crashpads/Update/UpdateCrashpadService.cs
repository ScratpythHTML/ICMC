using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Crashpads.Update;

/// <summary>
/// The service that updates a crashpad.
/// </summary>
public class UpdateCrashpadService : IUpdateCrashpadService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public UpdateCrashpadService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles updating a crashpad.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(UpdateCrashpadRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var crashpad = await _context.Crashpads
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (crashpad == null)
        {
            return CommandResult.Failure("Crashpad not found");
        }

        crashpad.Brand = request.Brand ?? crashpad.Brand;
        crashpad.DateOfPurchase = request.DateOfPurchase ?? crashpad.DateOfPurchase;
        crashpad.InspectedBy = request.InspectedBy ?? crashpad.InspectedBy;
        crashpad.LastInspection = request.LastInspection ?? crashpad.LastInspection;
        crashpad.ManufacturerExpiry = request.ManufacturerExpiry ?? crashpad.ManufacturerExpiry;
        crashpad.Model = request.Model ?? crashpad.Model;
        crashpad.NextInspection = request.NextInspection ?? crashpad.NextInspection;
        crashpad.ToughTag = request.ToughTag ?? crashpad.ToughTag;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
