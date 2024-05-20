using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Bullets
{
    public class WaspBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.NanoBullet);
            Projectile.aiStyle = 0;

            Projectile.width = Projectile.height = 8;
            DrawOffsetX = DrawOriginOffsetY = -2;

            Projectile.light = 0f;
            Projectile.scale = 1f;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = -Projectile.direction; // Like Bee Arrow

            if (Projectile.timeLeft < 596) Projectile.alpha -= 43;
            
            if (Projectile.wet && !Projectile.honeyWet && !Projectile.shimmerWet || Projectile.shimmerWet) Projectile.Kill();
        }

        public override void OnKill(int timeLeft)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                for (int i = 0; i < 4; i++) // "2" = 1 wasp, "4" = 2 wasps, ...
                {
                    if (i % 2 != 1 || Main.rand.NextBool(5)) // Spawning two wasps with 2 independent 20% chances to spawn an extra wasp
                    {
                        float speedX = Main.rand.Next(-25, 26);
                        float speedY = Main.rand.Next(-25, 26);

                        float multiplier = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                        multiplier = 0.25f / multiplier;

                        speedX *= multiplier;
                        speedY *= multiplier;

                        int wasp = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y,
                                                                                             speedX, speedY,
                                                                                             ProjectileID.Wasp,
                                                                                             21,
                                                                                             0f,
                                                                                             Main.myPlayer);
                        // By default, the penetration of wasp is 3
                        Main.projectile[wasp].penetrate = 2;
                    }

                }

            }

        }

    }

}
