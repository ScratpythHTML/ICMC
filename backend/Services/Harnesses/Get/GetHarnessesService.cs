using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Harnesses.Get;

/// <summary>
/// The service that gets all harnesses.
/// </summary>
public class GetHarnessesService : IGetHarnessesService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public GetHarnessesService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that gets all harnesses.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<HarnessDto[]>> Handle(GetHarnessesRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var result = await _context.Harnesses.Select(h => new HarnessDto
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
            Sex = h.Sex,
            StorageLocation = h.StorageLocation,
            LentTo = h.LentTo,
            LentBy = h.LentBy,
            ReturnedDate = h.ReturnedDate
        }).Where(h => h.StorageLocation == request.storageLocation).ToArrayAsync(cancellationToken);

        if (result == null)
        {
            return CommandResult.Failure<HarnessDto[]>("No harnesses found");
        }

        return CommandResult.WithResult(result);
    }
}