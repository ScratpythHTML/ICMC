using Domain.Entities;

namespace Handlers.Crashpads.Get;

/// <summary>
/// DTO for a crashpad.
/// </summary>
public class CrashpadDto
{
  /// <summary>
  /// Gets or sets the ID of the crashpad.
  /// </summary>
  public int Id { get; set; }
  /// <summary>
  /// Gets or sets the tough tag ID of the crashpad.
  /// </summary>
  public int? ToughTag { get; set; }
  /// <summary>
  /// Gets or sets the brand of the crashpad.
  /// </summary>
  public string? Brand { get; set; }
  /// <summary>
  /// Gets or sets the model name of the crashpad.
  /// </summary>
  public int? Model { get; set; }
  /// <summary>
  /// Gets or sets the date of purchase of the crashpad.
  /// </summary>
  public DateTimeOffset? DateOfPurchase { get; set; }
  /// <summary>
  /// Gets or sets the expiry date of the crashpad.
  /// </summary>
  public DateTimeOffset? ManufacturerExpiry { get; set; }
  /// <summary>
  /// Gets or sets the date of the last inspection of the crashpad.
  /// </summary>
  public DateTimeOffset? LastInspection { get; set; }
  /// <summary>
  /// Gets or sets the due date of the next inspection of the crashpad.
  /// </summary>
  public DateTimeOffset? NextInspection { get; set; }
  /// <summary>
  /// Gets of sets the User ID of the committee member who inspected of the crashpad.
  /// </summary>
  public Guid? InspectedBy { get; set; }
  /// <summary>
  /// Gets or sets the User navigation property.
  /// </summary>
  public virtual User? User { get; set; }
}
