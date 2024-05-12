using VanillaFlexibility.Content.Items.Weapons.Melee.Spears;
using VanillaFlexibility.Content.Items.Weapons.Ranged.Consumables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Common.Systems
{
    // https://github.com/tModLoader/tModLoader/blob/04710b280e1a03bc6e4ac34a5c4b894cefc792f0/ExampleMod/Common/Systems/ChestItemWorldGen.cs
    public class ChestItemWorldGen : ModSystem
	{
		public override void PostWorldGen()
		{
            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest == null) continue;
                
				Tile chestTile = Main.tile[chest.x, chest.y];
                if (chestTile.TileType == TileID.Containers2 && chestTile.TileFrameX == 10 * 36) // Sandstone Chest
                {
                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.ThrowingKnife || chest.item[inventoryIndex].type == ItemID.Shuriken)
                        {
                            chest.item[inventoryIndex].SetDefaults(ItemID.BoneDagger);
                            chest.item[inventoryIndex].stack = Main.rand.Next(25, 36);
                        }

                        if (chest.item[inventoryIndex].type == ItemID.WoodenArrow || chest.item[inventoryIndex].type == ItemID.FlamingArrow ||
                            chest.item[inventoryIndex].type == ItemID.JestersArrow)
                        {
                            chest.item[inventoryIndex].SetDefaults(ItemID.BoneJavelin);
                            chest.item[inventoryIndex].stack = Main.rand.Next(15, 26);
                            break;
                        }

                    }

                }

                if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 1 * 36 || // Gold Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 2 * 36 || // Locked Gold Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 8 * 36 || // Rich Mahogany Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 10 * 36 || // Ivy Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 11 * 36 || // Frozen Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 13 * 36 || // Skyware Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 15 * 36 || // Web Covered Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 16 * 36 || // Lihzahrd Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 17 * 36 || // Water Chest

                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 23 * 36 || // Locked Jungle Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 24 * 36 || // Locked Corruption Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 25 * 36 || // Locked Crimson Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 26 * 36 || // Locked Hallowed Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 27 * 36 || // Locked Ice Chest

                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 32 * 36 || // Mushroom Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 50 * 36 || // Granite Chest
                    chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 51 * 36 || // Marble Chest

                    chestTile.TileType == TileID.Containers2 && chestTile.TileFrameX == 4 * 36 || // Dead Man's Chest
                    chestTile.TileType == TileID.Containers2 && chestTile.TileFrameX == 10 * 36 || // Sandstone Chest
                    chestTile.TileType == TileID.Containers2 && chestTile.TileFrameX == 13 * 36) // Locked Desert Chest
                {
					if (WorldGen.genRand.NextBool(2)) continue;

                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
					{
                        if (chest.item[inventoryIndex].type == ItemID.Mace)
						{
							chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<MetalSpear>());
						}

                        if (chest.item[inventoryIndex].type == ItemID.ThrowingKnife)
                        {
                            chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<ShimmerKnife>());
                            chest.item[inventoryIndex].stack = Main.rand.Next(20, 26);
                        }

                        if (chest.item[inventoryIndex].type == ItemID.Shuriken)
                        {
                            chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<ShimmerShuriken>());
                            chest.item[inventoryIndex].stack = Main.rand.Next(30, 36);
                            break;
                        }

                    }

				}

			}

		}

	}

}
