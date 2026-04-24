namespace Domain.Entities;

/// <summary>
/// A rope owned by ICMC.
/// </summary>
public class Rope : GearItem
{
  /// <summary>
  /// The length of the rope.
  /// </summary>
  public int? Length { get; set; }
}