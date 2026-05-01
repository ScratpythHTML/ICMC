using Audacia.Commands;
using Domain.Entities;
using EntityFramework;

namespace Handlers.BelayDevices.Add;

/// <summary>
/// The handler that adds a belay device.
/// </summary>
public class AddBelayDeviceHandler : IAddBelayDeviceHandler
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public AddBelayDeviceHandler(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles adding a belay device.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(AddBelayDeviceRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var belayDevice = new BelayDevice
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

        _context.BelayDevices.Add(belayDevice);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }

}