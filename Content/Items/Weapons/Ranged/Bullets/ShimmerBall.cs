using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets
{
    public class ShimmerBall : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MusketBall);

            // Common Properties
            Item.value = 9; // Sell value: 9 / 5 = 1.8 Copper
            Item.rare = ItemRarityID.Green;

            // Weapon Properties
            Item.damage += 3; // 10
            Item.crit += 2; // 6
            Item.knockBack += 0.5f; // 2.5f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Bullets.ShimmerBall>();
            Item.shootSpeed += 0.25f; // 4.25f
        }

    }

}
