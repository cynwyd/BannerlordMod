using System;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace ExampleMod
{
    [HarmonyPatch(typeof(DefaultPartyTroopUpgradeModel), nameof(DefaultPartyTroopUpgradeModel.GetXpCostForUpgrade))]
    public static class GetXpCostForUpgradePostFix
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetXpCostForUpgrade(ref PartyBase party, ref CharacterObject characterObject, CharacterObject upgradeTarget, ref int __result)
        {
            if (upgradeTarget.Tier == 6)
            {
                __result *= 10;
            }
            else if (upgradeTarget.Tier == 5)
            {
                __result *= 4;
            }
            else if (upgradeTarget.Tier == 4)
            {
                __result *= 2;
            }
        }
    }
}
