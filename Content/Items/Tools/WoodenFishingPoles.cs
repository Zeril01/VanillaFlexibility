using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Tools
{
    // https://github.com/tModLoader/tModLoader/blob/45d71f0de361f7ef59349b64ee9ce504f9161845/ExampleMod/Content/Items/Tools/ExampleFishingRod.cs
    public class RichMahoganyFishingPole : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/Tools/WoodenFishingPoles/RichMahoganyFishingPole";

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);

            // Tool Properties
            Item.fishingPole += 2; // 7

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Tools.RichMahoganyBobber>();
            Item.shootSpeed += 0.5f; // 9.5f
        }

        public override void HoldItem(Player player) => player.accFishingLine = true;
        public override void ModifyFishingLine(Projectile bobber, ref Vector2 lineOriginOffset, ref Color lineColor) => lineOriginOffset = new Vector2(43, -36);
        
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.RichMahogany, 8)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class BorealWoodFishingPole : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/Tools/WoodenFishingPoles/BorealWoodFishingPole";

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);

            // Tool Properties
            Item.fishingPole += 1; // 6

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Tools.BorealWoodBobber>();
        }

        public override void HoldItem(Player player) => player.accFishingLine = true;
        public override void ModifyFishingLine(Projectile bobber, ref Vector2 lineOriginOffset, ref Color lineColor) => lineOriginOffset = new Vector2(43, -36);

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BorealWood, 8)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class AshWoodFishingPole : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/Tools/WoodenFishingPoles/AshWoodFishingPole";
        public override void SetStaticDefaults() => ItemID.Sets.CanFishInLava[Item.type] = true;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodFishingPole);

            // Tool Properties
            Item.fishingPole += 3; // 8

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Tools.AshWoodBobber>();
            Item.shootSpeed += 1f; // 10f
        }

        public override void HoldItem(Player player) => player.accFishingLine = true;
        public override void ModifyFishingLine(Projectile bobber, ref Vector2 lineOriginOffset, ref Color lineColor) => lineOriginOffset = new Vector2(43, -36);

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AshWood, 8)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

}
