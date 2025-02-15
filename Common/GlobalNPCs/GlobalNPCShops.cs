using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Common.GlobalNPCs
{
    // https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Common/GlobalNPCs/ExampleNPCShop.cs
    public class GlobalNPCShops : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant)
            {
                if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod) && shop.TryGetEntry(ItemID.WormholePotion, out NPCShop.Entry entry)) entry.Disable();
                shop.InsertBefore(ItemID.WoodenArrow, ItemID.WormholePotion, Condition.Multiplayer);
            }

            if (shop.NpcType == NPCID.SkeletonMerchant)
            {
                shop.InsertAfter(ItemID.BoneArrow, ModContent.ItemType<Content.Items.Weapons.Ranged.Bullets.BoneBall>(), Condition.MoonPhasesEvenQuarters); // 1, 2, 5, 6 Moon phases
            }
        }
    }
}