using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Bullets
{
    public class ReTungstenBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;

        public override bool PreAI()
        {
            // If projectile sprite faces up
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // So as not to block the muzzle of the weapon from which it appears
            if (Projectile.alpha > 0) Projectile.alpha -= 15;
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }

    }

}
