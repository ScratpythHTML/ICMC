namespace Domain.Entities;

/// <summary>
/// A user who is a member of ICMC.
/// </summary>
public class User
{
  /// <summary>
  /// Gets or sets the user ID.
  /// </summary>
  public Guid UserId { get; set; }
  /// <summary>
  /// Gets or sets the College ID (CID) of the user.
  /// </summary>
  public string? CID { get; set; }
  /// <summary>
  /// Gets or sets the first name of the user.
  /// </summary>
  public string? FirstName { get; set; }
  /// <summary>
  /// Gets or sets the second name of the user.
  /// </summary>
  public string? SecondName { get; set; }
  /// <summary>
  /// Gets or sets the imperial email address of the user.
  /// </summary>
  public string? UserEmail { get; set; }
  /// <summary>
  /// Gets or sets a value indicating if a user is an admin.
  /// </summary>
  public bool? IsAdmin { get; set; }
}