using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Melee.Spears
{
    // https://github.com/tModLoader/tModLoader/blob/04710b280e1a03bc6e4ac34a5c4b894cefc792f0/ExampleMod/Content/Projectiles/ExampleSpearProjectile.cs
    public class ColdMetalSpear : ModProjectile
    {
        protected virtual float HoldoutRangeMin => 30f;
        protected virtual float HoldoutRangeMax => 96f; // Spear have ~ 84f

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<MetalSpear>());

            Projectile.width = Projectile.height = 18;
        }
        
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            int duration = player.itemAnimationMax;
            player.heldProj = Projectile.whoAmI;

            if (Projectile.timeLeft > duration) Projectile.timeLeft = duration;

            Projectile.velocity = Vector2.Normalize(Projectile.velocity);
            float halfDuration = duration * 0.5f;
            float progress;

            if (Projectile.timeLeft < halfDuration) progress = Projectile.timeLeft / halfDuration;
                                               else progress = (duration - Projectile.timeLeft) / halfDuration;
            
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

            // Apply proper rotation to the sprite
            if (Projectile.spriteDirection == -1) Projectile.rotation += MathHelper.ToRadians(45f);
                                             else Projectile.rotation += MathHelper.ToRadians(135f);
            
            if (!Main.dedServ) // Avoid spawning dusts on dedicated servers
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.4f, 100, default, 1.2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X *= 4f;
                Main.dust[dust].velocity.Y *= 4f;
                Main.dust[dust].velocity = (Main.dust[dust].velocity + Projectile.velocity) / 2f;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(5)) target.AddBuff(BuffID.Frostburn, Main.rand.Next(120, 181));
        }

    }

}
