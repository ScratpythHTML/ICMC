using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Helmets.Get;

/// <summary>
/// The service that gets all helmets.
/// </summary>
public class GetHelmetsService : IGetHelmetsService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public GetHelmetsService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that gets all helmets.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<HelmetDto[]>> Handle(GetHelmetsRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var result = await _context.Helmets.Select(h => new HelmetDto
        {
            Id = h.Id,
            ToughTag = h.ToughTag,
            Brand = h.Brand,
            Model = h.Model,
            DateOfPurchase = h.DateOfPurchase,
            ManufacturerExpiry = h.ManufacturerExpiry,
            LastInspection = h.LastInspection,
            NextInspection = h.NextInspection,
            InspectedBy = h.InspectedBy,
            Size = h.Size,
            StorageLocation = h.StorageLocation
        }).Where(h => h.StorageLocation == request.storageLocation).ToArrayAsync(cancellationToken);

        if (result == null)
        {
            return CommandResult.Failure<HelmetDto[]>("No helmets found");
        }

        return CommandResult.WithResult(result);
    }
}