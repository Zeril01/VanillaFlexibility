using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets
{
    public class EndlessRainbowPouch : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.EndlessMusketPouch);

            // Common Properties
            Item.rare = ItemRarityID.Yellow;

            // Weapon Properties
            Item.damage += 6; // 13
            Item.knockBack += 3f; // 5f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Bullets.RainbowTear>();
            Item.shootSpeed -= 1f; // 3f
        }

    }

}
