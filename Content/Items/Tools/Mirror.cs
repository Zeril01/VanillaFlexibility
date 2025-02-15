namespace VanillaFlexibility.Content.Items.Tools
{
    public class Mirror : ModItem
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.IceMirror}";

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.color = Color.Crimson;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.itemTime == 0) player.ApplyItemTime(Item);
            else if (player.itemTime == player.itemTimeMax / 2)
            {
                player.RemoveAllGrapplingHooks();

                bool canSpawn = false;
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = player.width;
                Vector2 vector = new Vector2(num2, num3) * 16f + new Vector2(-num4 / 2 + 8, -player.height);
                while (!canSpawn && num < 100)
                {
                    num++;

                    int teleportStartX = 16 * 6; // 96
                    int teleportRangeX = Main.maxTilesX - 16 * 12; // 192
                    int teleportRangeY = 16 * 5; // 80
                    int teleportStartY = 16; // upper limit of the world

                    num2 = teleportStartX + Main.rand.Next(teleportRangeX);
                    num3 = teleportStartY + Main.rand.Next(teleportRangeY);
                    int num5 = 5;
                    num2 = (int)MathHelper.Clamp(num2, num5, Main.maxTilesX - num5);
                    num3 = (int)MathHelper.Clamp(num3, num5, Main.maxTilesY - num5);
                    vector = new Vector2(num2, num3) * 16f + new Vector2(-num4 / 2 + 8, -player.height);
                }
                player.position = vector;
            }

        }

        public static void SkyTeleportationPotion(Player player)
        {
            Vector2 vector = new(-5, 5);
            player.position += vector;
        }

    }

}
