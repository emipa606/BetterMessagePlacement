using Verse;

namespace Better_Message_Placement;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class Better_Message_PlacementSettings : ModSettings
{
    public float xOffsetPercent;
    public float yOffsetPercent;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref yOffsetPercent, "yOffsetPercent");
        Scribe_Values.Look(ref xOffsetPercent, "xOffsetPercent");
    }
}