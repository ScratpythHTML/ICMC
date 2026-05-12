namespace Domain.Entities;

/// <summary>
/// A user who is a member of ICMC.
/// </summary>
public class User
{
  /// <summary>
  /// The ID of the user.
  /// </summary>
  public int Id { get; set; }
  /// <summary>
  /// Gets or sets the College ID (CID) of the user.
  /// </summary>
  public string? CID { get; set; }
  /// <summary>
  /// Gets or sets the imperial email address of the user.
  /// </summary>
  public string? Email { get; set; }

  /// <summary>
  /// Gets or sets the full name of the user.
  /// </summary>
  public string? FullName { get; set; }

  /// <summary>
  /// Gets or sets a value indicating if a user is an admin.
  /// </summary>
  public bool? IsAdmin { get; set; }

  /// <summary>
  /// Gets or sets the member type of a user.
  /// </summary>
  public MemberType? MemberType { get; set; }
}