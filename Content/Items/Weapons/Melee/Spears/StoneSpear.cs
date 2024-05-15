using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Melee.Spears
{
    // https://github.com/tModLoader/tModLoader/blob/04710b280e1a03bc6e4ac34a5c4b894cefc792f0/ExampleMod/Content/Items/Weapons/ExampleSpear.cs
    public class StoneSpear : ModItem
    {
        public override void SetStaticDefaults() => ItemID.Sets.Spears[Item.type] = true;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Spear);

            // Common Properties
            Item.value = 125; // Sell value: 125 / 5 = 25 Copper
            Item.width = Item.height -= 2; // 30

            // Use Properties
            Item.useAnimation = Item.useTime += 2; // 33

            // Weapon Properties
            Item.damage -= 2; // 6
            Item.knockBack -= 0.7f; // 5.8f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Spears.StoneSpear>();
            Item.shootSpeed -= 0.45f; // 3.25f
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 7)
                .AddIngredient(ItemID.StoneBlock, 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

}
