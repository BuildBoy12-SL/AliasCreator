// -----------------------------------------------------------------------
// <copyright file="ProcessQueryPatch.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace AliasCreator.Patches
{
#pragma warning disable SA1118
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;
    using AliasCreator.Models;
    using HarmonyLib;
    using NorthwoodLib.Pools;
    using RemoteAdmin;
    using static HarmonyLib.AccessTools;

    /// <summary>
    /// Patches <see cref="CommandProcessor.ProcessQuery"/> to implement <see cref="Config.Aliases"/>.
    /// </summary>
    [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
    internal static class ProcessQueryPatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);

            Label retLabel = generator.DefineLabel();

            newInstructions.InsertRange(0, new[]
            {
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Call, Method(typeof(ProcessQueryPatch), nameof(FindAlias))),
                new CodeInstruction(OpCodes.Brtrue_S, retLabel),
            });

            newInstructions[newInstructions.Count - 1].labels.Add(retLabel);

            for (int z = 0; z < newInstructions.Count; z++)
                yield return newInstructions[z];

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }

        private static bool FindAlias(string query, CommandSender sender)
        {
            foreach (AliasModel aliasModel in Plugin.Instance.Config.Aliases)
            {
                if (aliasModel.Aliases.Any(alias => string.Equals(alias, query, System.StringComparison.OrdinalIgnoreCase)))
                {
                    CommandProcessor.ProcessQuery(aliasModel.TargetCommand, sender);
                    return true;
                }
            }

            return false;
        }
    }
}