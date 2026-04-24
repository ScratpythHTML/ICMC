namespace Domain.Entities;

/// <summary>
/// A carabiner owned by ICMC.
/// </summary>
public class Carabiner
{
  /// <summary>
  /// Gets or sets the ID of the carabiner.
  /// </summary>
  public int Id { get; set; }
  /// <summary>
  /// Gets or sets the tough tag ID of the carabiner.
  /// </summary>
  public int? ToughTag { get; set; }
  /// <summary>
  /// Gets or sets the brand of the carabiner.
  /// </summary>
  public string? Brand { get; set; }
  /// <summary>
  /// Gets or sets the model name of the carabiner.
  /// </summary>
  public int? Model { get; set; }
  /// <summary>
  /// Gets or sets the date of purchase of the carabiner.
  /// </summary>
  public DateTimeOffset? DateOfPurchase { get; set; }
  /// <summary>
  /// Gets or sets the expiry date of the carabiner cited by the manufacturer.
  /// </summary>
  public DateTimeOffset? ManufacturerExpiry { get; set; }
  /// <summary>
  /// Gets or sets the date of the last inspection of the carabiner.
  /// </summary>
  public DateTimeOffset? LastInspection { get; set; }
  /// <summary>
  /// Gets or sets the due date of the next inspection of the carabiner.
  /// </summary>
  public DateTimeOffset? NextInspection { get; set; }
  /// <summary>
  /// Gets of sets the User ID of the committee member who inspected the carabiner.
  /// </summary>
  public Guid? InspectedBy { get; set; }
  /// <summary>
  /// Gets or sets the User navigation property.
  /// </summary>
  public virtual User? User { get; set; }
}