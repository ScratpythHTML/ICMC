using Domain.Entities;

namespace Services.Users.Get;

/// <summary>
/// DTO for a user.
/// </summary>
public class UserDto
{
  /// <summary>
  /// Gets or sets the College ID (CID) of the user.
  /// </summary>
  public int CID { get; set; }
  /// <summary>
  /// Gets or sets the imperial email address of the user.
  /// </summary>
  public string? Email { get; set; }

  /// <summary>
  /// Gets or sets the first name of the user.
  /// </summary>
  public string? FirstName { get; set; }

  /// <summary>
  /// Gets or sets a value indicating if a user is an admin.
  /// </summary>
  public bool? IsAdmin { get; set; }

  /// <summary>
  /// Gets or sets the member type of a user.
  /// </summary>
  public MemberType? MemberType { get; set; }

  /// <summary>
  /// Gets or sets the second name of the user.
  /// </summary>
  public string? Surname { get; set; }
}