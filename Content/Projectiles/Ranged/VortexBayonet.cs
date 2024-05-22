using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged
{
    public class VortexBayonet : ModProjectile
    {
        public override void SetStaticDefaults() => ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            Projectile.aiStyle = 0;

            Projectile.width = Projectile.height = 6;
            DrawOffsetX = -4;
            DrawOriginOffsetY = -2;

            Projectile.light = 0f;
            Projectile.scale = 1f;

            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

            Projectile.extraUpdates = 2;

            Projectile.ArmorPenetration = 45;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;

        public override void AI()
        {
            // If projectile sprite faces up
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            if (Projectile.alpha > 0) Projectile.alpha -= 15;

            int totalDust = 9;
            for (int i = 0; i < totalDust; i++)
            {
                Dust dust = Dust.NewDustPerfect(Projectile.position, DustID.Vortex, Projectile.velocity * 0f, 200, default, 0.425f);
                dust.position = Projectile.Center - Projectile.velocity / totalDust * i;
                dust.noGravity = true;
            }

            // Chlorophyte Bullet have 250f ~ 20 tiles
            float maxDetectRadius = 187.5f; // ~ 15 tiles

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null) return;

            float rangeX = closestNPC.Center.X - Projectile.Center.X;
            float rangeY = closestNPC.Center.Y - Projectile.Center.Y;

            float speedMultiplayer = 8f / ((float)Math.Sqrt(rangeX * rangeX + rangeY * rangeY));
            rangeX *= speedMultiplayer;
            rangeY *= speedMultiplayer;

            Projectile.velocity.X = (Projectile.velocity.X * 10f + rangeX) / 11f;
            Projectile.velocity.Y = (Projectile.velocity.Y * 10f + rangeY) / 11f;
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

        public override void OnKill(int timeLeft) => SoundEngine.PlaySound(SoundID.Item10, Projectile.position); //? пыль
    }

}
