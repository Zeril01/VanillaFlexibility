using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Ranged.Arrows
{
    public class FrostfireArrow : ModProjectile
    {
        public override void SetStaticDefaults() => Main.projFrames[Projectile.type] = 10;
        
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.FrostburnArrow);
            AIType = ProjectileID.WoodenArrowFriendly;

            Projectile.width = Projectile.height = 8;
            DrawOffsetX = -5;
            DrawOriginOffsetY = -7;
        }

        private readonly int[] typesOfDust = [DustID.Torch, DustID.IceTorch];

        public override bool PreAI()
        {
            if (++Projectile.frameCounter >= 5) // 5 ticks per frame
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type]) Projectile.frame = 0;
            }

            if (!Main.dedServ) Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Main.rand.Next(typesOfDust), 0f, 0f, 100);
            return true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int[] typesOfBuff = [BuffID.OnFire, BuffID.Frostburn];
            if (Main.rand.NextBool(3)) target.AddBuff(Main.rand.Next(typesOfBuff), 3 * 60);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < 15; i++) Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Main.rand.Next(typesOfDust), 0f, 0f, 100);
        }

    }

}
