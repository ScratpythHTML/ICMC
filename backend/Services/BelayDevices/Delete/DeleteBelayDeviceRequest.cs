using Audacia.Commands;
using MediatR;

namespace Services.BelayDevices.Delete;

/// <summary>
/// A request to delete a belay device by ID.
/// </summary>
/// <param name="Id"></param>
public record DeleteBelayDeviceRequest(int Id) : IRequest<CommandResult>;