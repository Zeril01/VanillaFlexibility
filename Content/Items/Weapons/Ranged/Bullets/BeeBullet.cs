using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets
{
    public class BeeBullet : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MeteorShot);

            // Common Properties
            Item.value = 20; // Sell value: 20 / 5 = 4 Copper

            // Weapon Properties
            Item.damage -= 3; // 5
            Item.knockBack += 0.5f; // 1.5f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Bullets.BeeBullet>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
                .AddIngredient(ItemID.MusketBall, 150)
                .AddIngredient(ItemID.BeeWax)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }

}
