using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Harnesses.Update;

/// <summary>
/// The service for updating harnesses.
/// </summary>
public class UpdateHarnessService : IUpdateHarnessService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public UpdateHarnessService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles updating a harness.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(UpdateHarnessRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var harness = await _context.Harnesses
            .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (harness == null)
        {
            return CommandResult.Failure("Harness not found");
        }

        harness.Brand = request.Brand ?? harness.Brand;
        harness.DateOfPurchase = request.DateOfPurchase ?? harness.DateOfPurchase;
        harness.InspectedBy = request.InspectedBy ?? harness.InspectedBy;
        harness.LastInspection = request.LastInspection ?? harness.LastInspection;
        harness.ManufacturerExpiry = request.ManufacturerExpiry ?? harness.ManufacturerExpiry;
        harness.Model = request.Model ?? harness.Model;
        harness.NextInspection = request.NextInspection ?? harness.NextInspection;
        harness.Sex = request.Sex ?? harness.Sex;
        harness.Size = request.Size ?? harness.Size;
        harness.ToughTag = request.ToughTag ?? harness.ToughTag;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
