using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using static PulsarPluginLoader.Patches.HarmonyHelpers;

namespace Better_Drunk
{
    [HarmonyPatch(typeof(PLPlayer), "Update")]
    class PLPlayerUpdatePatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> targetSequence1 = new List<CodeInstruction>()    
            {
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "BAC")),
                new CodeInstruction(OpCodes.Ldc_R4, 0f),
                new CodeInstruction(OpCodes.Ldc_R4, 1f),
            };

            List<CodeInstruction> injectedSequence1 = new List<CodeInstruction>()
             {
                new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(PLPlayer), "BAC")),
                new CodeInstruction(OpCodes.Ldc_R4, 0f),
                new CodeInstruction(OpCodes.Ldc_R4, 100f)
            };

            IEnumerable<CodeInstruction> Modified = PatchBySequence(instructions, targetSequence1, injectedSequence1, PatchMode.REPLACE);

            List<CodeInstruction> targetSequence2 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_R4, 0.0015f),
            };

            List<CodeInstruction> injectedSequence2 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(Global), "AlcoholSubtract")),
            };

            return PatchBySequence(Modified, targetSequence2, injectedSequence2, PatchMode.REPLACE);
        }
    }
    [HarmonyPatch(typeof(PLPawnItem_Food), "OnAction")]
    class AlcoholPerDrink
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> targetSequence1 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_R4, 2f),
            };

            List<CodeInstruction> injectedSequence1 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(Global), "AlcoholPerDrink")),
            };

            IEnumerable<CodeInstruction> Modified = PatchBySequence(instructions, targetSequence1, injectedSequence1, PatchMode.REPLACE);

            List<CodeInstruction> targetSequence2 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldc_R4, 2f),
            };

            List<CodeInstruction> injectedSequence2 = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldsfld, AccessTools.Field(typeof(Global), "AlcoholPerDrink")),
            };

            return PatchBySequence(Modified, targetSequence2, injectedSequence2, PatchMode.REPLACE);
        }
    }
}
