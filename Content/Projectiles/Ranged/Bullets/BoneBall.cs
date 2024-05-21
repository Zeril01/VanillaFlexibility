using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Bullets
{
    public class BoneBall : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;

            Projectile.light = 0.25f;

            Projectile.penetrate = 2;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20; // Meteor Shot and High Velocity Bullet have "15"
        }
        
        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) => Projectile.damage = (int)(Projectile.damage * 0.5f);

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
        
    }

}
