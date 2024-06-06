using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Armor
{
    // https://github.com/tModLoader/tModLoader/blob/9c2197776fcc493fadbf456ee8f2f43b3d250397/ExampleMod/Content/Items/Armor/ExampleLeggings.cs

    [AutoloadEquip(EquipType.Legs)]
    public class FlinxFurPants : ModItem
    {
        public static readonly int SummonDamageBonus = 3;
        public static readonly int MoveSpeedBonus = 5;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(SummonDamageBonus, MoveSpeedBonus);

        public override void SetDefaults()
        {
            // Common Properties
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Green;
            Item.width = Item.height = 18;

            // Armor Properties
            Item.defense = 1;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += SummonDamageBonus / 100f;
            player.moveSpeed += MoveSpeedBonus / 100f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 8)
                .AddIngredient(ItemID.FlinxFur, 6)
                .AddIngredient(ItemID.GoldBar, 6)
                .AddTile(TileID.Loom)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Silk, 8)
                .AddIngredient(ItemID.FlinxFur, 6)
                .AddIngredient(ItemID.PlatinumBar, 6)
                .AddTile(TileID.Loom)
                .DisableDecraft()
                .Register();
        }

    }

}
