using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Consumables
{
    public class WoodenJavelin : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/WoodenJavelins/WoodenJavelin";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BoneJavelin);

            // Common Properties
            Item.value = 5; // Sell value: 5 / 5 = 1 Copper
            Item.rare = ItemRarityID.White;
            Item.width = Item.height = 24;

            // Use Properties
            Item.useAnimation = Item.useTime += 2; // 27

            // Weapon Properties
            Item.damage -= 7; // 13
            Item.knockBack -= 2f; // 3f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.WoodenJavelins.WoodenJavelin>();
            Item.shootSpeed -= 1.5f; // 8.5f
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.Wood, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class RichMahoganyJavelin : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/WoodenJavelins/RichMahoganyJavelin";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodenJavelin>());

            // Use Properties
            Item.useAnimation = Item.useTime -= 1;

            // Weapon Properties
            Item.damage += 1; // 14
            Item.knockBack += 1f; // 4f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.WoodenJavelins.RichMahoganyJavelin>();
            Item.shootSpeed += 0.5f; // 9f
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.RichMahogany, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class EbonwoodJavelin : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/WoodenJavelins/EbonwoodJavelin";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodenJavelin>());

            // Use Properties
            Item.useAnimation = Item.useTime -= 1; // 26

            // Weapon Properties
            Item.damage += 4; // 17
            Item.knockBack += 1f; // 4f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.WoodenJavelins.EbonwoodJavelin>();
            Item.shootSpeed += 0.5f; // 9f
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.Ebonwood, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class ShadewoodJavelin : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/WoodenJavelins/ShadewoodJavelin";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodenJavelin>());

            // Use Properties
            Item.useAnimation = Item.useTime -= 1; // 26

            // Weapon Properties
            Item.damage += 4; // 17
            Item.knockBack += 1f; // 4f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.WoodenJavelins.ShadewoodJavelin>();
            Item.shootSpeed += 0.5f; // 9f
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.Shadewood, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class PearlwoodJavelin : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/WoodenJavelins/PearlwoodJavelin";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodenJavelin>());

            // Use Properties
            Item.useAnimation = Item.useTime -= 5; // 22

            // Weapon Properties
            Item.damage += 23; // 36
            Item.knockBack += 2f; // 5f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.WoodenJavelins.PearlwoodJavelin>();
            Item.shootSpeed += 1f; // 9.5f
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.Pearlwood, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class BorealWoodJavelin : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/WoodenJavelins/BorealWoodJavelin";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodenJavelin>());

            // Weapon Properties
            Item.damage += 1; // 14
            Item.knockBack += 1f; // 4f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.WoodenJavelins.BorealWoodJavelin>();
            Item.shootSpeed += 0.5f; // 9f
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.BorealWood, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class PalmWoodJavelin : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/WoodenJavelins/PalmWoodJavelin";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodenJavelin>());

            // Use Properties
            Item.useAnimation = Item.useTime -= 1; // 26

            // Weapon Properties
            Item.damage += 1; // 14
            Item.knockBack += 1f; // 4f

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.WoodenJavelins.PalmWoodJavelin>();
            Item.shootSpeed += 0.5f; // 9f
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.PalmWood, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

    public class AshWoodJavelin : ModItem
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Items/WoodenJavelins/AshWoodJavelin";
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodenJavelin>());

            // Use Properties
            Item.useAnimation = Item.useTime -= 2; // 25

            // Weapon Properties
            Item.damage += 2; // 15

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.WoodenJavelins.AshWoodJavelin>();
            Item.shootSpeed += 1f; // 9.5f
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.AshWood, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

}
