using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets
{
    public class BoneBall : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MusketBall);

            // Common Properties
            Item.value = 20; // Sell value: 20 / 5 = 4 Copper

            // Weapon Properties
            Item.damage -= 1; // 6
            Item.knockBack -= 0.7f; // 1.3f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Bullets.BoneBall>();
            Item.shootSpeed -= 1.5f; // 2.5f
        }
        // This bullet can be obtained by buying from a Skeleton Merchant
    }

}
