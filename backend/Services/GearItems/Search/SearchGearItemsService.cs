using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.GearItems.Dtos;

namespace Services.GearItems.Search;

/// <summary>
/// The service that searches for all gear items.
/// </summary>
public class SearchGearItemsService : ISearchGearItemsService
{
    private readonly DatabaseContext _context;
    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public SearchGearItemsService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// The asynchronous method that searches for all gear items.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<GearItemDto[]>> Handle(SearchGearItemsRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var query = _context.GearItems.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(request.Search))
        {
            var searchTerm = request.Search.ToLower();
            query = query.Where(gi =>
                (gi.Brand != null && gi.Brand.ToLower().Contains(searchTerm)) ||
                (gi.Model != null && gi.Model.ToLower().Contains(searchTerm)) ||
                (gi.ToughTag != null && gi.ToughTag.ToLower().Contains(searchTerm))
            );
        }

        query = query.Where(gi =>
            (string.IsNullOrEmpty(request.Brand) || (gi.Brand != null && gi.Brand.ToLower().Contains(request.Brand.ToLower()))) &&
            (request.DateOfPurchase == null || gi.DateOfPurchase == request.DateOfPurchase) &&
            (request.ExpectedReturnDate == null || gi.ExpectedReturnDate == request.ExpectedReturnDate) &&
            (request.GearCategory == null || gi.GearCategory == request.GearCategory) &&
            (request.InspectedByUserId == null || gi.InspectedByUserId == request.InspectedByUserId) &&
            (request.LastInspection == null || gi.LastInspection == request.LastInspection) &&
            (request.Length == null || gi.Length == request.Length) &&
            (request.LentDate == null || gi.LentDate == request.LentDate) &&
            (request.LentToUserId == null || gi.LentToUserId == request.LentToUserId) &&
            (request.LentByUserId == null || gi.LentByUserId == request.LentByUserId) &&
            (request.ManufacturerExpiry == null || gi.ManufacturerExpiry == request.ManufacturerExpiry) &&
            (string.IsNullOrEmpty(request.Model) || (gi.Model != null && gi.Model.ToLower().Contains(request.Model.ToLower()))) &&
            (request.NextInspection == null || gi.NextInspection == request.NextInspection) &&
            (request.ReturnedDate == null || gi.ReturnedDate == request.ReturnedDate) &&
            (request.Size == null || gi.Size == request.Size) &&
            (request.Sex == null || gi.Sex == request.Sex) &&
            (request.StorageLocation == null || gi.StorageLocation == request.StorageLocation) &&
            (string.IsNullOrEmpty(request.ToughTag) || (gi.ToughTag != null && gi.ToughTag.ToLower().Contains(request.ToughTag.ToLower())))
        );

        var result = await query
            .Include(gi => gi.LentToUser)
            .Select(gi => new GearItemDto(
                gi.Id,
                gi.Brand,
                gi.DateOfPurchase,
                gi.ExpectedReturnDate,
                gi.GearCategory,
                gi.ImageUrl,
                gi.InspectedByUserId,
                gi.LastInspection,
                gi.Length,
                gi.LentByUserId,
                gi.LentDate,
                gi.LentToUserId,
                gi.LentToUser != null ? gi.LentToUser.FullName : null,
                gi.ManufacturerExpiry,
                gi.Model,
                gi.NextInspection,
                gi.ReturnedDate,
                gi.Sex,
                gi.Size,
                gi.StorageLocation,
                gi.ToughTag
            ))
            .ToArrayAsync(cancellationToken);

        return CommandResult.WithResult(result);
    }
}