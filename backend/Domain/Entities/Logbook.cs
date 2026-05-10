namespace Domain.Entities;

/// <summary>
/// The logbook of all gear.
/// </summary>
public class Logbook
{
    /// <summary>
    /// The ID of the gear log.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The piece of gear lent out.
    /// </summary>
    public int GearItemId { get; set; }
    /// <summary>
    /// The CID of the member the piece of gear was lent to.
    /// </summary>
    public string? LentTo { get; set; }
    /// <summary>
    /// The CID of the committee member that lent the piece of gear.
    /// </summary>
    public string? LentBy { get; set; }
    /// <summary>
    /// The date when the piece of gear was lent out.
    /// </summary>
    public DateTimeOffset? LentDate { get; set; }
    /// <summary>
    /// The date when the piece of gear was returned.
    /// </summary>
    public DateTimeOffset? ReturnedDate { get; set; }

}