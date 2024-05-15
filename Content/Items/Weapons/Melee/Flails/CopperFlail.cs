using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Melee.Flails
{
    // https://github.com/tModLoader/tModLoader/blob/ff5e30bb4ef89256f4dd8151812d79cd8d5930a0/ExampleMod/Content/Items/Weapons/ExampleFlail.cs
    public class CopperFlail : ModItem
    {
        public override void SetStaticDefaults() => ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Mace);

            // Common Properties
            Item.value = 500; // Sell value: 500 / 5 = 1 Silver
            Item.rare = ItemRarityID.White;
            Item.width = Item.height -= 4; // 24

            // Use Properties
            Item.useAnimation = Item.useTime += 5; // 50

            // Weapon Properties
            Item.damage -= 2; // 7
            Item.knockBack -= 0.6f; // 4f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Flails.CopperFlail>();
            Item.shootSpeed -= 1f; // 10f
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 2)
                .AddIngredient(ItemID.CopperBar, 7)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }

}
