using VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace VanillaFlexibility.Common.GlobalNPCs
{
    // https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Common/GlobalNPCs/ExampleNPCLoot.cs
    public class GlobalNPCLootChanges : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.SnowFlinx)
            {
                foreach (var rule in npcLoot.Get()) // Normal mode
                {
                    if (rule is DropBasedOnExpertMode dropBasedOnNormalMode
                        && dropBasedOnNormalMode.ruleForNormalMode is CommonDrop normalDropRule
                        && normalDropRule.itemId == ItemID.FlinxFur)
                    {
                        normalDropRule.amountDroppedMinimum += 1; // 2
                        normalDropRule.amountDroppedMaximum += 1; // 3
                    }

                }

                foreach (var rule in npcLoot.Get()) // Expert mode
                {
                    if (rule is DropBasedOnExpertMode dropBasedOnExpertMode
                        && dropBasedOnExpertMode.ruleForExpertMode is CommonDrop expertDropRule
                        && expertDropRule.itemId == ItemID.FlinxFur)
                    {
                        expertDropRule.amountDroppedMinimum += 2; // 3
                        expertDropRule.amountDroppedMaximum += 1; // 4
                    }

                }

            }

            if (npc.type == NPCID.HallowBoss) npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EndlessRainbowPouch>(), 4)); // 25%
        }

    }

}
