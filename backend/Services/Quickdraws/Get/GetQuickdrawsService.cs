using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Quickdraws.Get;

/// <summary>
/// The service that gets all quickdraws.
/// </summary>
public class GetQuickdrawsService : IGetQuickdrawsService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public GetQuickdrawsService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that gets all quickdraws.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<QuickdrawDto[]>> Handle(GetQuickdrawsRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var result = await _context.Quickdraws.Select(q => new QuickdrawDto
        {
            Id = q.Id,
            ToughTag = q.ToughTag,
            Brand = q.Brand,
            Model = q.Model,
            DateOfPurchase = q.DateOfPurchase,
            ManufacturerExpiry = q.ManufacturerExpiry,
            LastInspection = q.LastInspection,
            NextInspection = q.NextInspection,
            InspectedBy = q.InspectedBy,
            StorageLocation = q.StorageLocation
        }).Where(q => q.StorageLocation == request.storageLocation).ToArrayAsync(cancellationToken);

        if (result == null)
        {
            return CommandResult.Failure<QuickdrawDto[]>("No quickdraws found");
        }

        return CommandResult.WithResult(result);
    }
}