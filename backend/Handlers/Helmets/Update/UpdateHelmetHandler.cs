using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Helmets.Update;

public class UpdateHelmetHandler : IUpdateHelmetHandler
{
    private readonly DatabaseContext _context;

    public UpdateHelmetHandler(
        DatabaseContext context
    )
    {
        _context = context;
    }

    public async Task<CommandResult> Handle(UpdateHelmetRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var helmet = await _context.Helmets
            .FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (helmet == null)
        {
            return CommandResult.Failure("Helmet not found");
        }

        helmet.Brand = request.Brand ?? helmet.Brand;
        helmet.DateOfPurchase = request.DateOfPurchase ?? helmet.DateOfPurchase;
        helmet.InspectedBy = request.InspectedBy ?? helmet.InspectedBy;
        helmet.LastInspection = request.LastInspection ?? helmet.LastInspection;
        helmet.ManufacturerExpiry = request.ManufacturerExpiry ?? helmet.ManufacturerExpiry;
        helmet.Model = request.Model ?? helmet.Model;
        helmet.NextInspection = request.NextInspection ?? helmet.NextInspection;
        helmet.Size = request.Size ?? helmet.Size;
        helmet.ToughTag = request.ToughTag ?? helmet.ToughTag;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
