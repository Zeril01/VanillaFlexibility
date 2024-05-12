using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace NoAmmoNoGuns
{
    // Borrowed from here: https://github.com/GabeHasWon/SpiritMod/blob/638fa333f57498a04510c802c65de73f9a554adb/Utilities/GlowmaskUtils.cs#L211
    public static class GlowmaskUtils
    {
        public static void DrawItemGlowMaskWorld(SpriteBatch spriteBatch, Item item, Texture2D texture, float rotation, float scale)
        {
            spriteBatch.Draw(
                texture,
                new Vector2(item.position.X - Main.screenPosition.X + item.width / 2, item.position.Y - Main.screenPosition.Y + item.height - (texture.Height / 2)),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White * ((255f - item.alpha) / 255f),
                rotation,
                new Vector2(texture.Width / 2, texture.Height / 2),
                scale,
                SpriteEffects.None,
                0f);
        }

    }

}
