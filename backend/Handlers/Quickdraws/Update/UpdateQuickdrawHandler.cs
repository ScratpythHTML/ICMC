using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Quickdraws.Update;

public class UpdateQuickdrawHandler : IUpdateQuickdrawHandler
{
    private readonly DatabaseContext _context;

    public UpdateQuickdrawHandler(
        DatabaseContext context
    )
    {
        _context = context;
    }

    public async Task<CommandResult> Handle(UpdateQuickdrawRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var quickdraw = await _context.Quickdraws
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (quickdraw == null)
        {
            return CommandResult.Failure("Quickdraw not found");
        }

        quickdraw.Brand = request.Brand ?? quickdraw.Brand;
        quickdraw.DateOfPurchase = request.DateOfPurchase ?? quickdraw.DateOfPurchase;
        quickdraw.InspectedBy = request.InspectedBy ?? quickdraw.InspectedBy;
        quickdraw.LastInspection = request.LastInspection ?? quickdraw.LastInspection;
        quickdraw.ManufacturerExpiry = request.ManufacturerExpiry ?? quickdraw.ManufacturerExpiry;
        quickdraw.Model = request.Model ?? quickdraw.Model;
        quickdraw.NextInspection = request.NextInspection ?? quickdraw.NextInspection;
        quickdraw.ToughTag = request.ToughTag ?? quickdraw.ToughTag;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
