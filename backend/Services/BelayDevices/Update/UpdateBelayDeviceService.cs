using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.BelayDevices.Update;

/// <summary>
/// Handles updating a belay device.
/// </summary>
public class UpdateBelayDeviceService : IUpdateBelayDeviceService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public UpdateBelayDeviceService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles updating a belay device.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(UpdateBelayDeviceRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var belayDevice = await _context.BelayDevices
            .FirstOrDefaultAsync(bd => bd.Id == request.Id, cancellationToken)
            .ConfigureAwait(false);

        if (belayDevice == null)
        {
            return CommandResult.Failure("Belay device not found");
        }

        belayDevice.Brand = request.Brand ?? belayDevice.Brand;
        belayDevice.DateOfPurchase = request.DateOfPurchase ?? belayDevice.DateOfPurchase;
        belayDevice.InspectedBy = request.InspectedBy ?? belayDevice.InspectedBy;
        belayDevice.LastInspection = request.LastInspection ?? belayDevice.LastInspection;
        belayDevice.ManufacturerExpiry = request.ManufacturerExpiry ?? belayDevice.ManufacturerExpiry;
        belayDevice.Model = request.Model ?? belayDevice.Model;
        belayDevice.NextInspection = request.NextInspection ?? belayDevice.NextInspection;
        belayDevice.ToughTag = request.ToughTag ?? belayDevice.ToughTag;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}