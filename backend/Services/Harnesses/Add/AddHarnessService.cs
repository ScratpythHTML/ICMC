using Audacia.Commands;
using Domain.Entities;
using EntityFramework;

namespace Services.Harnesses.Add;

/// <summary>
/// The service that adds a harness.
/// </summary>
public class AddHarnessService : IAddHarnessService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public AddHarnessService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles adding a harness.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(AddHarnessRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var harness = new Harness
        {
            ToughTag = request.ToughTag,
            Brand = request.Brand,
            Model = request.Model,
            DateOfPurchase = DateTime.UtcNow,
            ManufacturerExpiry = request.ManufacturerExpiry,
            LastInspection = request.LastInspection,
            NextInspection = request.NextInspection,
            InspectedBy = request.InspectedBy,
            Size = request.Size,
            Sex = request.Sex
        };

        _context.Harnesses.Add(harness);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
