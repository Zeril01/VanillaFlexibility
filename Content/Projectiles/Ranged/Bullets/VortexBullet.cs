using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Bullets
{
    public class VortexBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.MoonlordBullet);
            AIType = ProjectileID.Bullet;

            Projectile.penetrate = 2;
            Projectile.localNPCHitCooldown = 10; // Meteor Shot and High Velocity Bullet have "15"

            Projectile.extraUpdates -= 1; // 4
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            float centerX = Main.screenPosition.X - 100f;
            float centerY = Main.screenPosition.Y - 100f;

            float speedXY = (float)Math.Sqrt(Projectile.oldVelocity.X * Projectile.oldVelocity.X + Projectile.oldVelocity.Y * Projectile.oldVelocity.Y);
            float spreadXY = Main.rand.Next(-75, 76) * 0.01f;

            int projType = ModContent.ProjectileType<VortexBayonet>();

            int damage = 15;

            if (Main.myPlayer == Projectile.owner)
            {
                int i = Main.rand.Next(1, 3);
                for (int l = 0; l < i; l++)
                {
                    if (Main.rand.NextBool(2))
                    {
                        if (Main.rand.NextBool(2))
                        {
                            centerX += 2120f;
                            speedXY *= -1f;
                            spreadXY *= -1f;
                        }

                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), centerX, target.Center.Y,
                                                                                  speedXY, spreadXY,
                                                                                  projType, damage, Projectile.knockBack, Projectile.owner);
                    }

                    else
                    {
                        if (Main.rand.NextBool(2))
                        {
                            centerY += 1280f;
                            speedXY *= -1f;
                            spreadXY *= -1f;
                        }

                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center.X, centerY,
                                                                                  spreadXY, speedXY,
                                                                                  projType, damage, Projectile.knockBack, Projectile.owner);
                    }

                }

            }

        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }

    }

}
