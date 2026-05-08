using Domain.Entities;

namespace Services.Ropes.Get;

/// <summary>
/// DTO for a rope.
/// </summary>
public class RopeDto
{
  /// <summary>
  /// Gets or sets the ID of the rope.
  /// </summary>
  public int Id { get; set; }
  /// <summary>
  /// Gets or sets the tough tag ID of the rope.
  /// </summary>
  public int? ToughTag { get; set; }
  /// <summary>
  /// Gets or sets the brand of the rope.
  /// </summary>
  public string? Brand { get; set; }
  /// <summary>
  /// Gets or sets the model name of the rope.
  /// </summary>
  public int? Model { get; set; }
  /// <summary>
  /// Gets or sets the date of purchase of the rope.
  /// </summary>
  public DateTimeOffset? DateOfPurchase { get; set; }
  /// <summary>
  /// Gets or sets the expiry date of the rope.
  /// </summary>
  public DateTimeOffset? ManufacturerExpiry { get; set; }
  /// <summary>
  /// Gets or sets the date of the last inspection of the rope.
  /// </summary>
  public DateTimeOffset? LastInspection { get; set; }
  /// <summary>
  /// Gets or sets the due date of the next inspection of the rope.
  /// </summary>
  public DateTimeOffset? NextInspection { get; set; }
  /// <summary>
  /// Gets of sets the User ID of the committee member who inspected of the rope.
  /// </summary>
  public Guid? InspectedBy { get; set; }
  /// <summary>
  /// The length of the rope.
  /// </summary>
  public int? Length { get; set; }
  /// <summary>
  /// Gets or sets the location where a piece of gear is stored.
  /// </summary>
  public StorageLocation StorageLocation { get; set; }
  /// <summary>
  /// Gets or sets the User navigation property.
  /// </summary>
  public virtual User? User { get; set; }
}
