using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Consumables.WoodenJavelins
{
    public class EbonwoodJavelin : ModProjectile
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Projectiles/WoodenJavelins/EbonwoodJavelin";

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<WoodenJavelin>());
            AIType = ProjectileID.JavelinFriendly;

            Projectile.width = Projectile.height = 10;
            DrawOffsetX = DrawOriginOffsetY = -2;
        }

        public override bool PreAI()
        {
            Projectile.spriteDirection = -Projectile.direction;
            if (Projectile.ai[0] > 22f)
            {
                Projectile.velocity.X *= 0.98f;
                Projectile.velocity.Y += 0.3f;
            }

            if (Projectile.lavaWet) Projectile.Kill();
            return true;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

            Vector2 usePos = Projectile.position;
            Vector2 rotationVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotationVector * 16f;

            for (int i = 0; i < 18; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, DustID.Ebonwood);
                dust.position = (dust.position + Projectile.Center) / 2f;
                dust.velocity += rotationVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotationVector * 6f;
            }

        }

    }

}
