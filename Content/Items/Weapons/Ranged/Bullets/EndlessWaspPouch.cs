using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets
{
    public class EndlessWaspPouch : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.EndlessMusketPouch);

            // Common Properties
            Item.rare = ItemRarityID.Lime;

            // Weapon Properties
            Item.damage += 3; // 10
            Item.knockBack -= 0.5f; // 1.5f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Bullets.WaspBullet>();
        }

    }

}
