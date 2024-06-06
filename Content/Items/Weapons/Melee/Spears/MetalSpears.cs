using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Melee.Spears
{
    // https://github.com/tModLoader/tModLoader/blob/04710b280e1a03bc6e4ac34a5c4b894cefc792f0/ExampleMod/Content/Items/Weapons/ExampleSpear.cs
    public class MetalSpear : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/Spears/MetalSpear";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Spears[Item.type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Mace;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Trident);

            // Common Properties
            Item.value = Item.sellPrice(gold: 2);
            Item.width = Item.height = 34;

            // Use Properties
            Item.useAnimation = Item.useTime -= 4; // 27

            // Weapon Properties
            Item.damage -= 1; // 13
            Item.knockBack -= 1f; // 5f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Spears.MetalSpear>();
            Item.shootSpeed += 0.3f; // 4.3f
        }

    }

    public class ColdMetalSpear : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/Spears/ColdMetalSpear";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Spears[Item.type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Mace;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<MetalSpear>());

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
