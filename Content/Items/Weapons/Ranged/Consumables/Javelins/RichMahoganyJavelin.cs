using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Weapons.Ranged.Consumables.Javelins
{
    public class RichMahoganyJavelin : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 99;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodenJavelin>());

            // Common Properties
            Item.value = 5; // Sell value: 5 / 5 = 1 Copper

            // Use Properties
            Item.useAnimation = Item.useTime = 26;

            // Weapon Properties
            Item.damage = 14;
            Item.knockBack = 3.5f;

            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Consumables.Javelins.RichMahoganyJavelin>();
            Item.shootSpeed = 9f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.RichMahogany, 2)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

    }

}
