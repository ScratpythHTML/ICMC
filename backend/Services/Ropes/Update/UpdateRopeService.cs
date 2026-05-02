using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Ropes.Update;

/// <summary>
/// The service for updating a rope.
/// </summary>
public class UpdateRopeService : IUpdateRopeService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public UpdateRopeService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles updating a rope.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(UpdateRopeRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var rope = await _context.Ropes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (rope == null)
        {
            return CommandResult.Failure("Rope not found");
        }

        rope.Brand = request.Brand ?? rope.Brand;
        rope.DateOfPurchase = request.DateOfPurchase ?? rope.DateOfPurchase;
        rope.InspectedBy = request.InspectedBy ?? rope.InspectedBy;
        rope.LastInspection = request.LastInspection ?? rope.LastInspection;
        rope.Length = request.Length ?? rope.Length;
        rope.ManufacturerExpiry = request.ManufacturerExpiry ?? rope.ManufacturerExpiry;
        rope.Model = request.Model ?? rope.Model;
        rope.NextInspection = request.NextInspection ?? rope.NextInspection;
        rope.ToughTag = request.ToughTag ?? rope.ToughTag;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
