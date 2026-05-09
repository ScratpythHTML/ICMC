namespace Domain.Entities;

/// <summary>
/// The category of a piece of gear.
/// </summary>
public enum GearCategory
{
    /// <summary>
    /// A belay device.
    /// </summary>
    BelayDevice = 0,
    /// <summary>
    /// A carabiner.
    /// </summary>
    Carabiner = 100,
    /// <summary>
    /// A crashpad.
    /// </summary>
    Crashpad = 200,
    /// <summary>
    /// A harness.
    /// </summary>
    Harness = 300,
    /// <summary>
    /// A helmet.
    /// </summary>
    Helmet = 400,
    /// <summary>
    /// A quickdraw.
    /// </summary>
    Quickdraw = 500,
    /// <summary>
    /// A rope.
    /// </summary>
    Rope = 600
}