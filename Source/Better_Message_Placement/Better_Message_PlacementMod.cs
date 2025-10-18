using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace Better_Message_Placement;

[StaticConstructorOnStartup]
internal class Better_Message_PlacementMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static Better_Message_PlacementMod instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public Better_Message_PlacementMod(ModContentPack content) : base(content)
    {
        instance = this;
        Settings = GetSettings<Better_Message_PlacementSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal Better_Message_PlacementSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Better Message Placement";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        var originalValue = Settings.xOffsetPercent + Settings.yOffsetPercent;

        Settings.xOffsetPercent = listingStandard.SliderLabeled(
            "BeMe.XOffset".Translate(Settings.xOffsetPercent.ToStringPercent()), Settings.xOffsetPercent, -1f, 1f,
            tooltip: "BeMe.XOffsetTT".Translate());
        Settings.yOffsetPercent = listingStandard.SliderLabeled(
            "BeMe.YOffset".Translate(Settings.yOffsetPercent.ToStringPercent()), Settings.yOffsetPercent, -1f, 1f,
            tooltip: "BeMe.YOffsetTT".Translate());

        if (Current.Game != null && originalValue != Settings.xOffsetPercent + Settings.yOffsetPercent)
        {
            Messages.Message("BeMe.TestMessage".Translate(), MessageTypeDefOf.SilentInput);
        }

        if (listingStandard.ButtonTextLabeledPct("BeMe.ResetToDefault".Translate(), "Reset".Translate(), 0.75f))
        {
            Settings.yOffsetPercent = 0f;
            Settings.xOffsetPercent = 0f;
        }

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("BeMe.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}