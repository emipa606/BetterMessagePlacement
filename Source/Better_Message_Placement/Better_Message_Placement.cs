using System.Reflection;
using HarmonyLib;
using Verse;

namespace Better_Message_Placement;

[StaticConstructorOnStartup]
public class Better_Message_Placement
{
    static Better_Message_Placement()
    {
        new Harmony("rimworld.dyrewulfe.bettermessageplacement").PatchAll(Assembly.GetExecutingAssembly());
    }
}