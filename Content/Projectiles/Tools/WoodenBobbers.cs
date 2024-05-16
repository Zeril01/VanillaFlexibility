using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Tools
{
    // https://github.com/tModLoader/tModLoader/blob/45d71f0de361f7ef59349b64ee9ce504f9161845/ExampleMod/Content/Projectiles/ExampleBobber.cs
    public class RichMahoganyBobber : ModProjectile
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Projectiles/WoodenBobbers/RichMahoganyBobber";

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BobberWooden);

            DrawOffsetX = 6;
            DrawOriginOffsetY = -8;
        }

    }

    public class BorealWoodBobber : ModProjectile
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Projectiles/WoodenBobbers/BorealWoodBobber";

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BobberWooden);

            DrawOffsetX = 6;
            DrawOriginOffsetY = -8;
        }

    }

    public class AshWoodBobber : ModProjectile
    {
        public override string Texture => VanillaFlexibility.AssetPath + "Textures/Projectiles/WoodenBobbers/AshWoodBobber";

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BobberWooden);

            DrawOffsetX = 6;
            DrawOriginOffsetY = -8;
        }

    }

}
