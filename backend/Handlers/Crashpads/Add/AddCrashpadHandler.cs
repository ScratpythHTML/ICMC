using Audacia.Commands;
using Domain.Entities;
using EntityFramework;

namespace Handlers.Crashpads.Add;

/// <summary>
/// The handler that adds a crashpad.
/// </summary>
public class AddCrashpadHandler : IAddCrashpadHandler
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public AddCrashpadHandler(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles adding a crashpad.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(AddCrashpadRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var crashpad = new Crashpad
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

        _context.Crashpads.Add(crashpad);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
