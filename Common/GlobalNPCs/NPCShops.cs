using VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Common.GlobalNPCs
{
    class NPCShops : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.SkeletonMerchant) shop.Add(ModContent.ItemType<BoneBall>(), Condition.MoonPhasesEvenQuarters); // 1, 2, 5, 6 moon phases
        }

    }

}
