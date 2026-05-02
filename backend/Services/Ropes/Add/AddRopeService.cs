using Audacia.Commands;
using Domain.Entities;
using EntityFramework;

namespace Services.Ropes.Add;

/// <summary>
/// The service that adds a rope.
/// </summary>
public class AddRopeService : IAddRopeService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public AddRopeService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles adding a rope.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(AddRopeRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var rope = new Rope
        {
            ToughTag = request.ToughTag,
            Brand = request.Brand,
            Model = request.Model,
            DateOfPurchase = DateTime.UtcNow,
            ManufacturerExpiry = request.ManufacturerExpiry,
            LastInspection = request.LastInspection,
            NextInspection = request.NextInspection,
            InspectedBy = request.InspectedBy,
            Length = request.Length
        };

        _context.Ropes.Add(rope);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
