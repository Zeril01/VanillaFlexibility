using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Consumables
{
    public class ShimmerKnife : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ThrowingKnife);

            Projectile.timeLeft = 5 * 60;
        }
        
        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;

        public override bool PreAI()
        {
            if (Projectile.timeLeft <= 280) Projectile.velocity.Y -= 0.4f * 2;
            
            if (Projectile.velocity.Y < -16f) Projectile.velocity.Y = -16f;
            
            if (Main.rand.NextBool(16)) // Shimmer Arrow have 8
            {
                Dust dust = Dust.NewDustPerfect(Projectile.Center, DustID.SparkForLightDisc, Projectile.velocity * 0f, 0, Main.hslToRgb(Main.rand.NextFloat(), 1f, 0.5f), 1f);
                dust.noGravity = true;
                dust.fadeIn = dust.scale + 0.05f;

                Dust dust1 = Dust.CloneDust(dust);
                dust1.color = Color.White;
                dust1.scale -= 0.3f;
            }
            return true;
        }
        
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

            // For more details check this: https://gist.github.com/Rijam/971b5252707860b65b582093580aa49c
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: true, ParticleOrchestraType.ShimmerArrow, new ParticleOrchestraSettings
            {
                PositionInWorld = Projectile.Center,
                MovementVector = Vector2.Zero
            });

        }

    }

}
