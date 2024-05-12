using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Melee.Spears
{
    // https://github.com/tModLoader/tModLoader/blob/04710b280e1a03bc6e4ac34a5c4b894cefc792f0/ExampleMod/Content/Items/Weapons/ExampleSpear.cs
    public class ColdMetalSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Spears[Item.type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Mace;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<MetalSpear>());

            // Common Properties
            Item.value = 110000; // Sell value: 11 / 5 = 2.2 Gold

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Spears.ColdMetalSpear>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MetalSpear>())
                .AddIngredient(ItemID.IceTorch, 99)
                .Register();
        }

    }

}
