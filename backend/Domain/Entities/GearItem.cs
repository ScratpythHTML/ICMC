namespace Domain.Entities;

/// <summary>
/// The base class of a piece of gear owned by ICMC.s
/// </summary>
public class GearItem
{
  /// <summary>
  /// Gets or sets the ID of the piece of gear.
  /// </summary>
  public int Id { get; set; }
  /// <summary>
  /// Gets or sets the tough tag ID of the piece of gear.
  /// </summary>
  public int? ToughTag { get; set; }
  /// <summary>
  /// Gets or sets the brand of the piece of gear.
  /// </summary>
  public string? Brand { get; set; }
  /// <summary>
  /// Gets or sets the model name of the piece of gear.
  /// </summary>
  public int? Model { get; set; }
  /// <summary>
  /// Gets or sets the date of purchase of the piece of gear.
  /// </summary>
  public DateTimeOffset? DateOfPurchase { get; set; }
  /// <summary>
  /// Gets or sets the expiry date of the piece of gear cited by the manufacturer.
  /// </summary>
  public DateTimeOffset? ManufacturerExpiry { get; set; }
  /// <summary>
  /// Gets or sets the date of the last inspection of the piece of gear.
  /// </summary>
  public DateTimeOffset? LastInspection { get; set; }
  /// <summary>
  /// Gets or sets the due date of the next inspection of the piece of gear.
  /// </summary>
  public DateTimeOffset? NextInspection { get; set; }
  /// <summary>
  /// Gets or sets the CID of the committee member who inspected the piece of gear.
  /// </summary>
  public int? InspectedBy { get; set; }
  /// <summary>
  /// Gets or sets the CID of the member who was lent the gear item.
  /// </summary>
  public int? LentTo { get; set; }
  /// <summary>
  /// Gets or sets the CID of the committee member who lent the geat item.
  /// </summary>
  public int? LentBy { get; set; }
  /// <summary>
  /// The date a user returned a borrowed item.
  /// </summary>
  public DateTimeOffset? ReturnedDate { get; set; }
  /// <summary>
  /// Gets or sets the User navigation property.
  /// </summary>
  public virtual User? User { get; set; }
  /// <summary>
  /// Gets or sets the location where a piece of gear is stored.
  /// </summary>
  public StorageLocation StorageLocation { get; set; }
}