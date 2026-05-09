using Domain.Entities;

namespace Services.Helmets.Get;

/// <summary>
/// DTO for a helmet.
/// </summary>
public class HelmetDto
{
  /// <summary>
  /// Gets or sets the ID of the helmet.
  /// </summary>
  public int Id { get; set; }
  /// <summary>
  /// Gets or sets the tough tag ID of the helmet.
  /// </summary>
  public int? ToughTag { get; set; }
  /// <summary>
  /// Gets or sets the brand of the helmet.
  /// </summary>
  public string? Brand { get; set; }
  /// <summary>
  /// Gets or sets the model name of the helmet.
  /// </summary>
  public int? Model { get; set; }
  /// <summary>
  /// Gets or sets the date of purchase of the helmet.
  /// </summary>
  public DateTimeOffset? DateOfPurchase { get; set; }
  /// <summary>
  /// Gets or sets the expiry date of the helmet.
  /// </summary>
  public DateTimeOffset? ManufacturerExpiry { get; set; }
  /// <summary>
  /// Gets or sets the date of the last inspection of the helmet.
  /// </summary>
  public DateTimeOffset? LastInspection { get; set; }
  /// <summary>
  /// Gets or sets the due date of the next inspection of the helmet.
  /// </summary>
  public DateTimeOffset? NextInspection { get; set; }
  /// <summary>
  /// Gets of sets the User ID of the committee member who inspected of the helmet.
  /// </summary>
  public int? InspectedBy { get; set; }
  /// <summary>
  /// The size of the helmet.
  /// </summary>
  public Size? Size { get; set; }
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
