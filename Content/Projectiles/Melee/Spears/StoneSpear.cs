using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Melee.Spears
{
    // https://github.com/tModLoader/tModLoader/blob/04710b280e1a03bc6e4ac34a5c4b894cefc792f0/ExampleMod/Content/Projectiles/ExampleSpearProjectile.cs
    public class StoneSpear : ModProjectile
    {
        protected virtual float HoldoutRangeMin => 18f;
        protected virtual float HoldoutRangeMax => 72f; // Spear have ~ 84f

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Spear);

            Projectile.width = Projectile.height = 12;
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
            return false;
        }

    }

}
