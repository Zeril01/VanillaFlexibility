using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Melee.Flails
{
    // https://github.com/tModLoader/tModLoader/blob/ff5e30bb4ef89256f4dd8151812d79cd8d5930a0/ExampleMod/Content/Items/Weapons/ExampleFlail.cs
    public class TinFlail : ModItem
    {
        public override void SetStaticDefaults() => ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<CopperFlail>());

            // Common Properties
            Item.value += 250; // Sell value: 750 / 5 = 1.5 Silver

            // Use Properties
            Item.useAnimation = Item.useTime -= 1; // 49

            // Weapon Properties
            Item.damage += 1; // 8

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Flails.TinFlail>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 2)
                .AddIngredient(ItemID.TinBar, 7)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }

}
