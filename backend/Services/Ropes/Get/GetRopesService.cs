using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Ropes.Get;

/// <summary>
/// The service that gets all ropes.
/// </summary>
public class GetRopesService : IGetRopesService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public GetRopesService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that gets all ropes.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<RopeDto[]>> Handle(GetRopesRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var result = await _context.Ropes.Select(r => new RopeDto
        {
            Id = r.Id,
            ToughTag = r.ToughTag,
            Brand = r.Brand,
            Model = r.Model,
            DateOfPurchase = r.DateOfPurchase,
            ManufacturerExpiry = r.ManufacturerExpiry,
            LastInspection = r.LastInspection,
            NextInspection = r.NextInspection,
            InspectedBy = r.InspectedBy,
            Length = r.Length,
            StorageLocation = r.StorageLocation
        }).Where(r => r.StorageLocation == request.storageLocation).ToArrayAsync(cancellationToken);

        if (result == null)
        {
            return CommandResult.Failure<RopeDto[]>("No ropes found");
        }

        return CommandResult.WithResult(result);
    }
}