using Audacia.Commands;
using Domain.Entities;
using EntityFramework;

namespace Services.Carabiners.Add;

/// <summary>
/// The service that adds a carabiner.
/// </summary>
public class AddCarabinerService : IAddCarabinerService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public AddCarabinerService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles adding a carabiner.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(AddCarabinerRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var carabiner = new Carabiner
        {
            ToughTag = request.ToughTag,
            Brand = request.Brand,
            Model = request.Model,
            DateOfPurchase = DateTime.UtcNow,
            ManufacturerExpiry = request.ManufacturerExpiry,
            LastInspection = request.LastInspection,
            NextInspection = request.NextInspection,
            InspectedBy = request.InspectedBy
        };

        _context.Carabiners.Add(carabiner);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
