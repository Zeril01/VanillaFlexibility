﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Bullets
{
    public class ShimmerBall : ModProjectile
    {
        public override void SetStaticDefaults() => Main.projFrames[Projectile.type] = 2;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;

            DrawOriginOffsetY = -2;

            Projectile.timeLeft = 30;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;

        public override bool PreAI()
        {
            if (Main.rand.NextBool(2)) Projectile.frame = 0;
                                  else Projectile.frame = 1;

            if (!Main.dedServ)
            {
                if (Projectile.timeLeft < 27 && Main.rand.NextBool(16)) // Shimmer Arrow have 8
                {
                    Dust dust = Dust.NewDustPerfect(Projectile.Center, DustID.SparkForLightDisc, Projectile.velocity * 0f, 0, Main.hslToRgb(Main.rand.NextFloat(), 1f, 0.5f), 1f);
                    dust.noGravity = true;
                    dust.fadeIn = dust.scale + 0.05f;

                    Dust dust1 = Dust.CloneDust(dust);
                    dust1.color = Color.White;
                    dust1.scale -= 0.3f;
                }

            }
            return true;
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

            // For more details check this: https://gist.github.com/Rijam/971b5252707860b65b582093580aa49c
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: true, ParticleOrchestraType.ShimmerArrow, new ParticleOrchestraSettings
            {
                PositionInWorld = Projectile.Center,
                MovementVector = Vector2.Zero
            });

        }

    }

}
