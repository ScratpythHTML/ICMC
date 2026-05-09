using Domain.Entities;

namespace Services.Carabiners.Get;

/// <summary>
/// DTO for a carabiner.
/// </summary>
public class CarabinerDto
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
  /// Gets or sets the expiry date of the carabiner.
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
  /// Gets or sets the User ID of the committee member who inspected of the carabiner.
  /// </summary>
  public int? InspectedBy { get; set; }
  /// <summary>
  /// Gets or sets the location where a piece of gear is stored.
  /// </summary>
  public StorageLocation StorageLocation { get; set; }
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
}
