using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Consumables.Javelins
{
    public class WoodenJavelin : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Javelin);

            // Common Properties
            Item.value = 4; // Sell value: 4 / 5 = 0.8 Copper
            Item.width = Item.height = 24;

            // Use Properties
            Item.useAnimation = Item.useTime = 27;

            // Weapon Properties
            Item.damage = 13;
            Item.knockBack = 3f;

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.Javelins.WoodenJavelin>();
            Item.shootSpeed = 8.5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.Wood, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

}
