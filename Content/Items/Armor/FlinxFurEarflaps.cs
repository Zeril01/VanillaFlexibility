using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Items.Armor
{
    // https://github.com/tModLoader/tModLoader/blob/9c2197776fcc493fadbf456ee8f2f43b3d250397/ExampleMod/Content/Items/Armor/ExampleHelmet.cs

    [AutoloadEquip(EquipType.Head)]
    public class FlinxFurEarflaps : ModItem
    {
        public static readonly int SummonDamageBonus = 3;
        public static readonly int WhipRangeMultiplierBonus = 10;
        public static readonly int MaxTurretIncrease = 1;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(SummonDamageBonus, WhipRangeMultiplierBonus);
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults() => SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(MaxTurretIncrease);
        
        public override void SetDefaults()
        {
            // Common Properties
            Item.value = Item.sellPrice(gold: 1, silver: 50);
            Item.rare = ItemRarityID.Green;
            Item.width = Item.height = 18;

            // Armor Properties
            Item.defense = 1;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += SummonDamageBonus / 100f;
            player.whipRangeMultiplier += WhipRangeMultiplierBonus / 100f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.FlinxFurCoat && legs.type == ModContent.ItemType<FlinxFurPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.maxTurrets += MaxTurretIncrease;
            player.buffImmune[BuffID.Frozen] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 6)
                .AddIngredient(ItemID.FlinxFur, 4)
                .AddIngredient(ItemID.GoldBar, 4)
                .AddTile(TileID.Loom)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Silk, 6)
                .AddIngredient(ItemID.FlinxFur, 4)
                .AddIngredient(ItemID.PlatinumBar, 4)
                .AddTile(TileID.Loom)
                .DisableDecraft()
                .Register();
        }

    }

}
