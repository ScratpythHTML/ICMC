namespace Domain.Entities;

/// <summary>
/// A harness owned by ICMC.
/// </summary>
public class Harness
{
  /// <summary>
  /// Gets or sets the ID of the harness.
  /// </summary>
  public int Id { get; set; }
  /// <summary>
  /// Gets or sets the tough tag ID of the harness.
  /// </summary>
  public int? ToughTag { get; set; }
  /// <summary>
  /// Gets or sets the brand of the harness.
  /// </summary>
  public string? Brand { get; set; }
  /// <summary>
  /// Gets or sets the model name of the harness.
  /// </summary>
  public int? Model { get; set; }
  /// <summary>
  /// Gets or sets the date of purchase of the harness.
  /// </summary>
  public DateTimeOffset? DateOfPurchase { get; set; }
  /// <summary>
  /// Gets or sets the expiry date of the harness cited by the manufacturer.
  /// </summary>
  public DateTimeOffset? ManufacturerExpiry { get; set; }
  /// <summary>
  /// Gets or sets the date of the last inspection of the harness.
  /// </summary>
  public DateTimeOffset? LastInspection { get; set; }
  /// <summary>
  /// Gets or sets the due date of the next inspection of the harness.
  /// </summary>
  public DateTimeOffset? NextInspection { get; set; }
  /// <summary>
  /// Gets of sets the User ID of the committee member who inspected the harness.
  /// </summary>
  public Guid? InspectedBy { get; set; }
  /// <summary>
  /// Gets or sets the User navigation property.
  /// </summary>
  public virtual User? User { get; set; }
}