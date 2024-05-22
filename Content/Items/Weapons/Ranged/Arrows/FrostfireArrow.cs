using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Arrows
{
    public class FrostfireArrow : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FrostburnArrow);

            // Common Properties
            Item.value = 20; // Sell value: 20 / 5 = 4 Copper
            Item.rare = ItemRarityID.Blue;

            // Weapon Properties
            Item.damage += 1; // 8
            Item.knockBack += 0.2f; // 2.4f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Arrows.FrostfireArrow>();
            Item.shootSpeed += 0.25f; // 4f
        }

        public override void AddRecipes()
        {
            CreateRecipe(10)
                .AddIngredient(ItemID.FlamingArrow, 10)
                .AddIngredient(ItemID.IceTorch)
                .Register();

            CreateRecipe(10)
                .AddIngredient(ItemID.FrostburnArrow, 10)
                .AddIngredient(ItemID.Torch)
                .Register();
        }

    }

}
