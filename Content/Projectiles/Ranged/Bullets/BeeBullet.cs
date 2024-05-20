using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Bullets
{
    public class BeeBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SilverBullet);
            Projectile.aiStyle = 0;

            Projectile.width = Projectile.height = 6;
            DrawOffsetX = DrawOriginOffsetY = -2;

            Projectile.light = 0f;
            Projectile.scale = 1f;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = -Projectile.direction; // Like Bee Arrow

            if (Projectile.timeLeft < 597)
            {
                Projectile.alpha -= 51;
                if (Projectile.alpha < 0) Projectile.alpha = 0;
            }

            if (Projectile.wet && !Projectile.honeyWet && !Projectile.shimmerWet) Projectile.Kill();

            if (Projectile.shimmerWet)
            {
                Projectile.velocity.Y -= 0.2f;
                if (Projectile.velocity.Y < 0f) Projectile.Kill();
            }

        }

        public override void OnKill(int timeLeft)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                for (int i = 0; i < 2; i++) // "2" = 1 bee, "4" = 2 bees, ...
                {
                    if (i % 2 != 1 || Main.rand.NextBool(4)) // Spawning one bee with 1 independent 25% chances to spawn an extra bee
                    {
                        float speedX = (Main.rand.Next(-35, 36) * 0.01f) - Projectile.oldVelocity.X / 16f;
                        float speedY = (Main.rand.Next(-35, 36) * 0.01f) - Projectile.oldVelocity.Y / 16f;

                        int bee = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y,
                                                                                            speedX, speedY,
                                                                                Main.player[Projectile.owner].beeType(),
                                                                                            9,
                                                                                Main.player[Projectile.owner].beeKB(0f),
                                                                                Main.myPlayer);
                        // By default, the penetration of bee is 3
                        Main.projectile[bee].penetrate = 2;
                    }

                }

            }

        }

    }

}
