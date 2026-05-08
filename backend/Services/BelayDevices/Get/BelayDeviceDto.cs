using Domain.Entities;

namespace Services.BelayDevices.Get;

/// <summary>
/// DTO for a belay device.
/// </summary>
public class BelayDeviceDto
{
  /// <summary>
  /// Gets or sets the ID of the belay device.
  /// </summary>
  public int Id { get; set; }
  /// <summary>
  /// Gets or sets the tough tag ID of the belay device.
  /// </summary>
  public int? ToughTag { get; set; }
  /// <summary>
  /// Gets or sets the brand of the belay device.
  /// </summary>
  public string? Brand { get; set; }
  /// <summary>
  /// Gets or sets the model name of the belay device.
  /// </summary>
  public int? Model { get; set; }
  /// <summary>
  /// Gets or sets the date of purchase of the belay device.
  /// </summary>
  public DateTimeOffset? DateOfPurchase { get; set; }
  /// <summary>
  /// Gets or sets the expiry date of the belay device cited by the manufacturer.
  /// </summary>
  public DateTimeOffset? ManufacturerExpiry { get; set; }
  /// <summary>
  /// Gets or sets the date of the last inspection of the belay device.
  /// </summary>
  public DateTimeOffset? LastInspection { get; set; }
  /// <summary>
  /// Gets or sets the due date of the next inspection of the belay device.
  /// </summary>
  public DateTimeOffset? NextInspection { get; set; }
  /// <summary>
  /// Gets of sets the User ID of the committee member who inspected the belay device.
  /// </summary>
  public Guid? InspectedBy { get; set; }
  /// <summary>
  /// Gets or sets the location where a piece of gear is stored.
  /// </summary>
  public StorageLocation StorageLocation { get; set; }
}