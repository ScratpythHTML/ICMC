using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Crashpads.Get;

/// <summary>
/// The service that gets all crashpads.
/// </summary>
public class GetCrashpadsService : IGetCrashpadsService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public GetCrashpadsService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that gets all crashpads.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<CrashpadDto[]>> Handle(GetCrashpadsRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var result = await _context.Crashpads.Select(c => new CrashpadDto
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
            StorageLocation = c.StorageLocation,
            LentTo = c.LentTo,
            LentBy = c.LentBy,
            ReturnedDate = c.ReturnedDate
        }).Where(c => c.StorageLocation == request.storageLocation).ToArrayAsync(cancellationToken);

        if (result == null)
        {
            return CommandResult.Failure<CrashpadDto[]>("No crashpads found");
        }

        return CommandResult.WithResult(result);
    }
}