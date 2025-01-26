using System;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace ExampleMod
{
    [HarmonyPatch(typeof(DefaultSettlementLoyaltyModel), nameof(DefaultSettlementLoyaltyModel.CalculateGoldGainDueToHighLoyalty))]
    public static class CalculateGoldGainDueToHighLoyaltyPostFix
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateGoldGainDueToHighLoyalty(Town town, ref ExplainedNumber explainedNumber)
        {
            // Current bonus per point of loyalty above 75 is about 1% per point. This increases that 4-fold, giving much higher bonuses if maintaining high loyalty
            float num = MBMath.Map(town.Loyalty, 75f, 100f, 0f, 20f);
            explainedNumber.AddFactor((float)num * 0.04f);
        }
    }
}
