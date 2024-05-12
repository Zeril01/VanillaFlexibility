using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Consumables
{
    public class ShimmerKnife : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PoisonedKnife);

            // Common Properties
            Item.value = 70; // Sell value: 70 / 5 = 14 Copper
            Item.rare = ItemRarityID.Blue;
            Item.width = 10;
            Item.height = 18;

            // Weapon Properties
            Item.damage = 15;

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.ShimmerKnife>();
        }

    }

}
