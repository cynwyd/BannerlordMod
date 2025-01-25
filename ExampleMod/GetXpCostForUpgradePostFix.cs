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
                if (upgradeTarget.IsMounted)
                {
                    __result *= 10;
                } else
                {
                    __result *= 5;
                }
            }
            else if (upgradeTarget.Tier == 5)
            {
                if (upgradeTarget.IsMounted)
                {
                    __result *= 5;
                }
                else
                {
                    __result *= 2;
                }
            }
            else if (upgradeTarget.Tier == 4)
            {
                if (upgradeTarget.IsMounted)
                {
                    __result *= 3;
                }
            }
        }
    }
}
