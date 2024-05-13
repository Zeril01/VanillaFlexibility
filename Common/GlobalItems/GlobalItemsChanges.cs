using VanillaFlexibility.Content.Items.Weapons.Melee.Spears;
using VanillaFlexibility.Content.Items.Weapons.Ranged.Bullets;
using VanillaFlexibility.Content.Items.Weapons.Ranged.Consumables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Common.GlobalItems
{
    public class ShimmerTransformGlobalChanges : GlobalItem
    {
        public override void SetStaticDefaults()
        {
            // M-E-L-E-E
            // Flails
            ItemID.Sets.ShimmerTransformToItem[ItemID.Mace] = ModContent.ItemType<MetalSpear>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.FlamingMace] = ModContent.ItemType<MetalSpear>();

            // R-A-N-G-E-D
            // Consumables
            ItemID.Sets.ShimmerTransformToItem[ItemID.Shuriken] = ModContent.ItemType<ShimmerShuriken>();
            ItemID.Sets.ShimmerTransformToItem[ItemID.ThrowingKnife] = ModContent.ItemType<ShimmerKnife>();

            // Bullets
            ItemID.Sets.ShimmerTransformToItem[ItemID.MusketBall] = ModContent.ItemType<ShimmerBall>();
        }

    }

    public class MusketBallGlobalChanges : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type == ItemID.MusketBall;

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.MusketBall, 35)
                  .AddRecipeGroup(RecipeGroupID.IronBar)
                  .AddTile(TileID.Anvils)
                  .Register();
        }

    }

    public class TungstenBulletGlobalChanges : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstantiation) => item.type == ItemID.TungstenBullet;

        public override void SetDefaults(Item item)
        {
            item.shoot = ModContent.ProjectileType<Content.Projectiles.Ranged.Bullets.ReTungstenBullet>();
        }

    }

}
