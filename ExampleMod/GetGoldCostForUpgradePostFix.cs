using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace ExampleMod
{
    [HarmonyPatch(typeof(DefaultPartyTroopUpgradeModel), nameof(DefaultPartyTroopUpgradeModel.GetGoldCostForUpgrade))]
    public static class GetGoldCostForUpgradePostFix
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetGoldCostForUpgrade(ref PartyBase party, ref CharacterObject characterObject, CharacterObject upgradeTarget, ref int __result)
        {
            if (upgradeTarget.Tier == 6)
            {
                __result += 8000;
            } else if (upgradeTarget.Tier == 5)
            {
                __result += 3000;
            } else if (upgradeTarget.Tier == 4)
            {
                __result += 500;
            }
        }
    }
}
