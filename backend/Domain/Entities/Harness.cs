namespace Domain.Entities;

/// <summary>
/// A harness owned by ICMC.
/// </summary>
public class Harness : GearItem
{
  /// <summary>
  /// The size of the harness.
  /// </summary>
  public Size? Size { get; set; }
  /// <summary>
  /// The sex categorisation of the harness.
  /// </summary>
  public Sex? Sex { get; set; }
}