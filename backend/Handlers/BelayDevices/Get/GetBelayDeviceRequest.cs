using MediatR;
using Audacia.Commands;

namespace Handlers.BelayDevices.Get;

/// <summary>
/// A request to get a belay device by ID.
/// </summary>
/// <param name="Id"></param>
public record GetBelayDeviceRequest(int Id) : IRequest<CommandResult<BelayDeviceDto>>;