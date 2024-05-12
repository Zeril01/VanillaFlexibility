using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Melee.Spears
{
    // https://github.com/tModLoader/tModLoader/blob/04710b280e1a03bc6e4ac34a5c4b894cefc792f0/ExampleMod/Content/Items/Weapons/ExampleSpear.cs
    public class MetalSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Spears[Item.type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.Mace;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Spear);

            // Common Properties
            Item.rare = ItemRarityID.Blue;
            Item.width = Item.height = 34;

            // Use Properties
            Item.useAnimation = Item.useTime = 27;

            // Weapon Properties
            Item.damage = 12;
            Item.knockBack = 4.8f;

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Spears.MetalSpear>();
            Item.shootSpeed = 4.3f;
        }

    }

}
