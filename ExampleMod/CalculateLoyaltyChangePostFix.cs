using System;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace ExampleMod
{
    [HarmonyPatch(typeof(DefaultSettlementLoyaltyModel), nameof(DefaultSettlementLoyaltyModel.CalculateLoyaltyChange))]
    public static class CalculateLoyaltyChangePostFix
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateLoyaltyChange(Town town, ref ExplainedNumber __result)
        {
            // If you have less than 6 settlements (villages+castles+towns), you do not get the loyalty debuff
            if (town.Settlement.OwnerClan.Settlements.Count < 6)
            {
                __result.Add(2.0f);
            }
        }
    }
}
