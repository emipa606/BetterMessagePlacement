using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace Better_Message_Placement;

[HarmonyPatch(typeof(Messages), nameof(Messages.MessagesDoGUI))]
public class Messages_MessagesDoGUI
{
    private static readonly FieldInfo vector2Y = AccessTools.Field(typeof(Vector2), "y");
    private static readonly FieldInfo vector2X = AccessTools.Field(typeof(Vector2), "x");

    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codeInstructions = instructions as CodeInstruction[] ?? instructions.ToArray();
        var prev = codeInstructions.First();
        var patchedY = false;
        var patchedX = false;

        foreach (var code in codeInstructions)
        {
            yield return code;
            if (patchedY && patchedX)
            {
                continue;
            }

            if (prev.opcode == OpCodes.Ldfld && (FieldInfo)prev.operand == vector2Y)
            {
                patchedY = true;
                yield return new CodeInstruction(OpCodes.Call,
                    AccessTools.Method(typeof(Messages_MessagesDoGUI), nameof(yOffsetAdjustment)));
                yield return new CodeInstruction(OpCodes.Add);
            }

            if (prev.opcode == OpCodes.Ldfld && (FieldInfo)prev.operand == vector2X)
            {
                patchedX = true;
                yield return new CodeInstruction(OpCodes.Call,
                    AccessTools.Method(typeof(Messages_MessagesDoGUI), nameof(xOffsetAdjustment)));
                yield return new CodeInstruction(OpCodes.Add);
            }

            prev = code;
        }
    }

    private static int yOffsetAdjustment()
    {
        var offset = (int)Messages.MessagesTopLeftStandard.y;
        if (Find.CurrentMap == null)
        {
            return offset;
        }

        var scale = Find.ColonistBar.Scale;
        var rows = 3;
        if (scale > 0.42f)
        {
            rows = 2;
        }

        if (scale > 0.58f)
        {
            rows = 1;
        }

        offset += (int)(Find.ColonistBar.Size.y + (24f * scale)) * rows;

        offset += (int)(Prefs.ScreenHeight * Better_Message_PlacementMod.instance.Settings.yOffsetPercent);

        return offset;
    }

    private static int xOffsetAdjustment()
    {
        var offset = (int)Messages.MessagesTopLeftStandard.x;
        if (Find.CurrentMap == null)
        {
            return offset;
        }

        offset += (int)(Prefs.ScreenWidth * Better_Message_PlacementMod.instance.Settings.xOffsetPercent);

        return offset;
    }
}