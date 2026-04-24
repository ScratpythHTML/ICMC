namespace Domain.Entities;

/// <summary>
/// A helmet owned by ICMC.
/// </summary>
public class Helmet : GearItem
{
  /// <summary>
  /// The size of the helmet.
  /// </summary>
  public Size? Size { get; set; }
}