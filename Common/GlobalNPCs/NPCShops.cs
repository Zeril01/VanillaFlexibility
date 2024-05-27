using VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Common.GlobalNPCs
{
    // https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Common/GlobalNPCs/ExampleNPCShop.cs
    class NPCShops : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant) shop.InsertAfter(ItemID.Torch, ItemID.WormholePotion);
            
            if (shop.NpcType == NPCID.SkeletonMerchant) shop.InsertAfter(ItemID.BoneArrow, ModContent.ItemType<BoneBall>(), Condition.MoonPhasesEvenQuarters); // 1, 2, 5, 6 moon phases
        }

    }

}
