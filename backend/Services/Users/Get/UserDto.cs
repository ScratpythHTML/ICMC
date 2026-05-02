using Domain.Entities;

namespace Services.Users.Get;

/// <summary>
/// DTO for a user.
/// </summary>
public class UserDto
{
  /// <summary>
  /// Gets or sets the ID of the user.
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
  /// Gets or sets a value indicating if a user is an admin of the user.
  /// </summary>
  public bool? IsAdmin { get; set; }
}
