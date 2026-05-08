using Audacia.Commands;
using MediatR;

namespace Services.Quickdraws.Get;

/// <summary>
/// Interface for the service that gets quickdraws.
/// </summary>
public interface IGetQuickdrawsService : IRequestHandler<GetQuickdrawsRequest, CommandResult<QuickdrawDto[]>>;