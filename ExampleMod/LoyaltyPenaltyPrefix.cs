using System;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace ExampleMod
{
    [HarmonyPatch(typeof(DefaultSettlementLoyaltyModel), "get_SettlementOwnerDifferentCultureLoyaltyEffect")]
    public static class SettlementOwnerDifferentCultureLoyaltyEffectPatch
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static bool Prefix(ref float __result)
        {
            // Reduce differing culture penalty to be -2 instead of -3
            __result = -2f;
            return false;   // Skip the original getter
        }
    }
}
