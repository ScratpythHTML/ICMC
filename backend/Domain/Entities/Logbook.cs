namespace Domain.Entities;

/// <summary>
/// The logbook of all gear.
/// </summary>
public class Logbook
{
    /// <summary>
    /// The ID of the log entry.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The piece of gear lent out.
    /// </summary>
    public int GearItemId { get; set; }
    /// <summary>
    /// Gets or sets the navigation property of the associated Gear Item.
    /// </summary>
    public GearItem? GearItem { get; set; }
    /// <summary>
    /// Gets or sets the Id of the committee member who inspected the piece of gear.
    /// </summary>
    public int? InspectedByUserId { get; set; }
    /// <summary>
    /// Gets or sets the navigation property to the associated User.
    /// </summary>
    public User? InspectedByUser { get; set; }
    /// <summary>
    /// The CID of the member the piece of gear was lent to.
    /// </summary>
    public int? LentToUserId { get; set; }
    /// <summary>
    /// Gets or sets the navigation property of the associated User.
    /// </summary>
    public User? LentToUser { get; set; }
    /// <summary>
    /// The CID of the committee member that lent the piece of gear.
    /// </summary>
    public int? LentByUserId { get; set; }
    /// <summary>
    /// Gets or sets the navigation property of the associated User.
    /// </summary>
    public User? LentByUser { get; set; }
    /// <summary>
    /// The date when the piece of gear was lent out.
    /// </summary>
    public DateTimeOffset? LentDate { get; set; }
    /// <summary>
    /// The date when the piece of gear was returned.
    /// </summary>
    public DateTimeOffset? ReturnedDate { get; set; }

}