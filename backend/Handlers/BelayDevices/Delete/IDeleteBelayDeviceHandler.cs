using Audacia.Commands;
using MediatR;

namespace Handlers.BelayDevices.Delete;

/// <summary>
/// The interface for the handler that deletes a belay device.
/// </summary>
public interface IDeleteBelayDeviceHandler : IRequestHandler<DeleteBelayDeviceRequest, CommandResult>
{
}