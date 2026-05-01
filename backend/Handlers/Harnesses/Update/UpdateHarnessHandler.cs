using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Harnesses.Update;

public class UpdateHarnessHandler : IUpdateHarnessHandler
{
    private readonly DatabaseContext _context;

    public UpdateHarnessHandler(
        DatabaseContext context
    )
    {
        _context = context;
    }

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
