using System;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.Party;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ExampleMod
{
    [HarmonyPatch(typeof(DefaultPartyHealingModel), nameof(DefaultPartyHealingModel.GetSurvivalChance))]
    public static class GetSurvivalChancePostFix
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetSurvivalChance(PartyBase party, CharacterObject character, TaleWorlds.Core.DamageTypes damageType, bool canDamageKillEvenIfBlunt, ref float __result)
        {
            // With all surgeon skills, should give tier 6 troops 95%, 5 -> 90%, 4 
            if (!character.IsHero)
            {
                if (character.Tier == 6)
                {
                    __result *= 1.32f;
                    Console.WriteLine(__result);
                }
                else if (character.Tier == 5)
                {
                    __result *= 1.25f;
                }
                else if (character.Tier == 4)
                {
                    __result *= 1.18f;
                }
            }
        }
    }
}
