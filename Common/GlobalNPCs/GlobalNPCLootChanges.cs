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
            if (npc.type == NPCID.HallowBoss) npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EndlessRainbowPouch>(), 4)); // 25%
        }

    }

}
