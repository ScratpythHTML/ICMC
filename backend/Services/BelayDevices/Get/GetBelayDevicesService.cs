using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.BelayDevices.Get;

/// <summary>
/// The service that gets all belay devices.
/// </summary>
public class GetBelayDevicesService : IGetBelayDevicesService
{
    private readonly DatabaseContext _context;
    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public GetBelayDevicesService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that gets all belay devices.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<BelayDeviceDto[]>> Handle(GetBelayDevicesRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var result = await _context.BelayDevices.Select(bd => new BelayDeviceDto
        {
            Id = bd.Id,
            ToughTag = bd.ToughTag,
            Brand = bd.Brand,
            DateOfPurchase = bd.DateOfPurchase,
            Model = bd.Model,
            ManufacturerExpiry = bd.ManufacturerExpiry,
            LastInspection = bd.LastInspection,
            NextInspection = bd.NextInspection,
            InspectedBy = bd.InspectedBy,
            StorageLocation = bd.StorageLocation

        }).Where(bd => bd.StorageLocation == request.storageLocation).ToArrayAsync(cancellationToken);

        if (result == null)
        {
            return CommandResult.Failure<BelayDeviceDto[]>("No belay devices found");
        }

        return CommandResult.WithResult(result);
    }
}