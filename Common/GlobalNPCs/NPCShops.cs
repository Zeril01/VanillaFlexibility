using VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Common.GlobalNPCs
{
    // https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Common/GlobalNPCs/ExampleNPCShop.cs
    public class NPCShops : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant && !ModLoader.TryGetMod("CalamityMod", out Mod calamityMod)) shop.InsertAfter(ItemID.Torch, ItemID.WormholePotion, Condition.Multiplayer);
            
            if (shop.NpcType == NPCID.SkeletonMerchant) shop.InsertAfter(ItemID.BoneArrow, ModContent.ItemType<BoneBall>(), Condition.MoonPhasesEvenQuarters); // 1, 2, 5, 6 moon phases
        }

    }

}
