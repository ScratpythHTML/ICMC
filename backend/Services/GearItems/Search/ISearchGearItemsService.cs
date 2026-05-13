using Audacia.Commands;
using MediatR;
using Services.GearItems.Dtos;

namespace Services.GearItems.Search;

/// <summary>
/// Interface for the service that searches for gear items.
/// </summary>
public interface ISearchGearItemsService : IRequestHandler<SearchGearItemsRequest, CommandResult<GearItemDto[]>>;