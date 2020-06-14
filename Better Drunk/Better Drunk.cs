using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Better_Drunk
{
    [HarmonyPatch(typeof(PLPlayer), "Update")]
    class AlcoholMax
    {
        //private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        //{
        //    List<CodeInstruction> targetSequence = new List<CodeInstruction>()
        //    {
        //        new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "BAC")),
        //        new CodeInstruction(OpCodes.Ldc_R4, 0),
        //        new CodeInstruction(OpCodes.Ldc_R4, 1),
        //    };

        //    List<CodeInstruction> injectedSequence = new List<CodeInstruction>()
        //    {
        //        new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "BAC")),
        //        new CodeInstruction(OpCodes.Ldc_R4, 0),
        //        new CodeInstruction(OpCodes.Ldc_R4, 100),
        //    };

        //    return HarmonyHelpers.PatchBySequence(instructions, targetSequence, injectedSequence, PatchMode.REPLACE);
        //}
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> instructionList = instructions.ToList();

            instructionList[412].opcode = OpCodes.Ldsfld;
            instructionList[412].operand = AccessTools.Field(typeof(Global), "AlcoholMax");

            return instructionList.AsEnumerable();
        }
    }
    [HarmonyPatch(typeof(PLPlayer), "Update")]
    class AlcoholSubtract
    {
        //private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        //{
        //    List<CodeInstruction> targetSequence = new List<CodeInstruction>()
        //    {
        //        new CodeInstruction(OpCodes.Ldc_R4, 0.0015),
        //    };

        //    List<CodeInstruction> injectedSequence = new List<CodeInstruction>()
        //    {
        //        new CodeInstruction(OpCodes.Ldc_R4, 0.015),
        //    };

        //    return HarmonyHelpers.PatchBySequence(instructions, targetSequence, injectedSequence, PatchMode.REPLACE);
        //}
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> instructionList = instructions.ToList();

            instructionList[404].opcode = OpCodes.Ldsfld;
            instructionList[404].operand = AccessTools.Field(typeof(Global), "AlcoholSubtract"); ;

            return instructionList.AsEnumerable();
        }
    }
    [HarmonyPatch(typeof(PLPawnItem_Food), "OnAction")]
    class AlcoholPerDrink
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> instructionList = instructions.ToList();

            instructionList[73].opcode = OpCodes.Ldsfld;
            instructionList[73].operand = AccessTools.Field(typeof(Global), "AlcoholPerDrink");

            return instructionList.AsEnumerable();
        }
    }
}
