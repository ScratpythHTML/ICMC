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
  public string? ToughTag { get; set; }
  /// <summary>
  /// Gets or sets the brand of the piece of gear.
  /// </summary>
  public string? Brand { get; set; }
  /// <summary>
  /// Gets or sets the model name of the piece of gear.
  /// </summary>
  public string? Model { get; set; }
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
  /// Gets or sets the Id of the committee member who inspected the piece of gear.
  /// </summary>
  public int? InspectedByUserId { get; set; }
  /// <summary>
  /// Gets or sets the navigation property to the associated User.
  /// </summary>
  public User? InspectedByUser { get; set; }
  /// <summary>
  /// Gets or sets the Id of the member who was lent the piece of gear.
  /// </summary>
  public int? LentToUserId { get; set; }
  /// <summary>
  /// Gets or sets the navigation property to the associated User.
  /// </summary>
  public User? LentToUser { get; set; }
  /// <summary>
  /// Gets or sets the Id of the committee member who lent the geat item.
  /// </summary>
  public int? LentByUserId { get; set; }
  /// <summary>
  /// Gets or sets the navigation property of the associated User.
  /// </summary>
  public User? LentByUser { get; set; }
  /// <summary>
  /// The date a user was lent a piece of gear.
  /// </summary>
  public DateTimeOffset? LentDate { get; set; }
  /// <summary>
  /// The date a user returned a borrowed item.
  /// </summary>
  public DateTimeOffset? ReturnedDate { get; set; }
  /// <summary>
  /// The date a user should return the gear item by.
  /// </summary>
  public DateTimeOffset? ExpectedReturnDate { get; set; }
  /// <summary>
  /// Gets or sets the location where a piece of gear is stored.
  /// </summary>
  public StorageLocation StorageLocation { get; set; }
  /// <summary>
  /// The size of the piece of gear.
  /// </summary>
  public Size? Size { get; set; }
  /// <summary>
  /// The sex categorisation of the piece of gear.
  /// </summary>
  public Sex? Sex { get; set; }
  /// <summary>
  /// The length of the piece of gear.
  /// </summary>
  public int? Length { get; set; }
  /// <summary>
  /// The category of the piece of gear.
  /// </summary>
  public GearCategory GearCategory { get; set; }
  /// <summary>
  /// The URL of the image of the piece of gear.
  /// </summary>
  public string? ImageUrl { get; set; }
}