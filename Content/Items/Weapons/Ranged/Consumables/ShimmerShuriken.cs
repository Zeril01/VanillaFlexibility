using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Consumables
{
    public class ShimmerShuriken : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Shuriken);

            // Common Properties
            Item.value = 25; // Sell value: 25 / 5 = 5 Copper
            Item.rare = ItemRarityID.Blue;
            Item.width = Item.height = 20;

            // Weapon Properties
            Item.damage += 3; // 13

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.ShimmerShuriken>();
            Item.shootSpeed += 3f; // 12f
        }

    }

}
