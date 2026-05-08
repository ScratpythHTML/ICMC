using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Carabiners.Get;

/// <summary>
/// The service that gets all carabiners.
/// </summary>
public class GetCarabinersService : IGetCarabinersService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public GetCarabinersService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that gets all carabiners.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<CarabinerDto[]>> Handle(GetCarabinersRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var result = await _context.Carabiners.Select(c => new CarabinerDto
        {
            Id = c.Id,
            ToughTag = c.ToughTag,
            Brand = c.Brand,
            Model = c.Model,
            DateOfPurchase = c.DateOfPurchase,
            ManufacturerExpiry = c.ManufacturerExpiry,
            LastInspection = c.LastInspection,
            NextInspection = c.NextInspection,
            InspectedBy = c.InspectedBy,
            StorageLocation = c.StorageLocation
        }).Where(c => c.StorageLocation == request.storageLocation).ToArrayAsync(cancellationToken);

        if (result == null)
        {
            return CommandResult.Failure<CarabinerDto[]>("No carabiners found");
        }

        return CommandResult.WithResult(result);
    }
}