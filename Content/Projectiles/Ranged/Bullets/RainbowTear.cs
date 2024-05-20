using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Bullets
{
    // https://github.com/tModLoader/tModLoader/blob/36b15838674c600d4839fc640998377def0f3024/ExampleMod/Content/Projectiles/ExampleHomingProjectile.cs
    public class RainbowTear : ModProjectile
    {
        public override void SetStaticDefaults() => ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
            Projectile.aiStyle = 0;

            Projectile.extraUpdates += 1; // 3
        }

        public override void AI()
        {
            // If projectile sprite faces up
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            if (Projectile.timeLeft < 597)
            {
                Projectile.alpha -= 16;
                if (Projectile.alpha < 128) Projectile.alpha = 128;

                int totalDust = 12;
                for (int i = 0; i < totalDust; i++)
                {
                    Dust dust = Dust.NewDustPerfect(Projectile.position - Projectile.velocity / totalDust * i, DustID.RainbowMk2, Projectile.velocity * 0f, 0, Main.hslToRgb(Main.player[Projectile.owner].miscCounterNormalized * 9f % 1f, 1f, 0.5f), 0.625f);
                    dust.noGravity = true;
                }

            }

            if (Projectile.shimmerWet && Projectile.velocity.Y > 0f) // Bounce off
            {
                Projectile.velocity.Y *= -1f;
                Projectile.netUpdate = true;

                Projectile.shimmerWet = false;
                Projectile.wet = false;
            }

            // Chlorophyte Bullet have 250f ~ 20 tiles
            float maxDetectRadius = 281.25f; // ~ 22.5 tiles (for Calamity balance)

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null) return;

            float rangeX = closestNPC.Center.X - Projectile.Center.X;
            float rangeY = closestNPC.Center.Y - Projectile.Center.Y;

            float speedMultiplayer = 8f / ((float)Math.Sqrt(rangeX * rangeX + rangeY * rangeY));
            rangeX *= speedMultiplayer;
            rangeY *= speedMultiplayer;

            Projectile.velocity.X = (Projectile.velocity.X * 7f + rangeX) / 8f;
            Projectile.velocity.Y = (Projectile.velocity.Y * 7f + rangeY) / 8f;
        }

        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }

                }

            }
            return closestNPC;
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }

    }

}
