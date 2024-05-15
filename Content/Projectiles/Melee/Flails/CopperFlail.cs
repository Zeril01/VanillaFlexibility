using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace VanillaFlexibility.Content.Projectiles.Melee.Flails
{
    // https://github.com/tModLoader/tModLoader/blob/ff5e30bb4ef89256f4dd8151812d79cd8d5930a0/ExampleMod/Content/Projectiles/ExampleAdvancedFlailProjectile.cs
    public class CopperFlail : ModProjectile
    {
        private const string ChainTexturePath = "VanillaFlexibility/Content/Projectiles/Melee/Flails/CopperFlailChain";
        private static Asset<Texture2D> chainTexture;

        private enum AIState
        {
            Spinning, LaunchingForward, Retracting, /*UnusedState,*/ ForsedRetracting, Ricochet, Dropping
        }

        private AIState CurrentAIState
        {
            get => (AIState)Projectile.ai[0];
            set => Projectile.ai[0] = (float)value;
        }

        public ref float StateTimer => ref Projectile.ai[1];
        public ref float CollisionCounter => ref Projectile.localAI[0];
        public ref float SpinningStateTimer => ref Projectile.localAI[1];

        public override void Load() => chainTexture = ModContent.Request<Texture2D>(ChainTexturePath);
        public override void SetStaticDefaults() => ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Type] = true;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Mace);
            Projectile.aiStyle = 0;

            Projectile.width = Projectile.height = 16;
            DrawOffsetX = DrawOriginOffsetY = -3;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.active || player.dead || player.noItems || player.CCed || Vector2.Distance(Projectile.Center, player.Center) > 900f || (Main.myPlayer == Projectile.owner && Main.mapFullscreen))
            {
                Projectile.Kill();
                return;
            }

            Vector2 mountedCenter = player.MountedCenter;
            bool shouldOwnerHitCheck = false;

            int launchTimeLimit = 11; // Mace have 13
            float launchSpeed = 10f; // Mace have 12f

            float retractAcceleration = 3f;
            float maxRetractSpeed = 6f; // Mace have 8f
            float forcedRetractAcceleration = 6f;
            float maxForcedRetractSpeed = 11f; // Mace have 13f

            // Scaling these speeds and accelerations by the players melee speed
            float meleeSpeedMultiplier = player.GetTotalAttackSpeed(DamageClass.Melee);
            launchSpeed *= meleeSpeedMultiplier;
            retractAcceleration *= meleeSpeedMultiplier;
            maxRetractSpeed *= meleeSpeedMultiplier;
            forcedRetractAcceleration *= meleeSpeedMultiplier;
            maxForcedRetractSpeed *= meleeSpeedMultiplier;
            float launchRange = launchSpeed * launchTimeLimit;

            switch (CurrentAIState)
            {
                case AIState.Spinning:

                    {
                        shouldOwnerHitCheck = true;
                        if (Projectile.owner == Main.myPlayer)
                        {
                            Vector2 unitVectorTowardsMouse = mountedCenter.DirectionTo(Main.MouseWorld).SafeNormalize(Vector2.UnitX * player.direction);
                            player.ChangeDir((unitVectorTowardsMouse.X > 0f).ToDirectionInt());

                            if (!player.channel)
                            {
                                CurrentAIState = AIState.LaunchingForward;
                                StateTimer = 0f;
                                Projectile.velocity = unitVectorTowardsMouse * launchSpeed + player.velocity;
                                Projectile.Center = mountedCenter;
                                Projectile.netUpdate = true;
                                Projectile.ResetLocalNPCHitImmunity();
                                break;
                            }

                        }

                        SpinningStateTimer++;
                        Vector2 offsetFromPlayer = new Vector2(player.direction).RotatedBy((float)Math.PI * 10f * (SpinningStateTimer / 60f) * player.direction);

                        offsetFromPlayer.Y *= 0.8f;
                        if (offsetFromPlayer.Y * player.gravDir > 0f) offsetFromPlayer.Y *= 0.5f;

                        Projectile.Center = mountedCenter + offsetFromPlayer * 30f + new Vector2(0, player.gfxOffY);
                        Projectile.velocity = Vector2.Zero;
                        Projectile.localNPCHitCooldown = 15; // Like in Vanilla
                        break;
                    }

                case AIState.LaunchingForward:

                    {
                        bool shouldSwitchToRetracting = StateTimer++ >= launchTimeLimit;
                        shouldSwitchToRetracting |= Projectile.Distance(mountedCenter) >= 800f; // Max launch length

                        if (player.controlUseItem)
                        {
                            CurrentAIState = AIState.Dropping;
                            StateTimer = 0f;
                            Projectile.netUpdate = true;
                            Projectile.velocity *= 0.2f;
                            break;
                        }

                        if (shouldSwitchToRetracting)
                        {
                            CurrentAIState = AIState.Retracting;
                            StateTimer = 0f;
                            Projectile.netUpdate = true;
                            Projectile.velocity *= 0.3f;
                        }

                        player.ChangeDir((player.Center.X < Projectile.Center.X).ToDirectionInt());
                        break;
                    }

                case AIState.Retracting:

                    {
                        Vector2 unitVectorTowardsPlayer = Projectile.DirectionTo(mountedCenter).SafeNormalize(Vector2.Zero);
                        if (Projectile.Distance(mountedCenter) <= maxRetractSpeed)
                        {
                            Projectile.Kill();
                            return;
                        }

                        if (player.controlUseItem)
                        {
                            CurrentAIState = AIState.Dropping;
                            StateTimer = 0f;
                            Projectile.netUpdate = true;
                            Projectile.velocity *= 0.2f;
                        }

                        else
                        {
                            Projectile.velocity *= 0.98f;
                            Projectile.velocity = Projectile.velocity.MoveTowards(unitVectorTowardsPlayer * maxRetractSpeed, retractAcceleration);
                            player.ChangeDir((player.Center.X < Projectile.Center.X).ToDirectionInt());
                        }
                        break;
                    }

                // case AIState.UnusedState
                    
                case AIState.ForsedRetracting:

                    {
                        Projectile.tileCollide = false;
                        Vector2 unitVectorTowardsPlayer = Projectile.DirectionTo(mountedCenter).SafeNormalize(Vector2.Zero);

                        if (Projectile.Distance(mountedCenter) <= maxForcedRetractSpeed)
                        {
                            Projectile.Kill();
                            return;
                        }

                        Projectile.velocity *= 0.98f;
                        Projectile.velocity = Projectile.velocity.MoveTowards(unitVectorTowardsPlayer * maxForcedRetractSpeed, forcedRetractAcceleration);
                        Vector2 target = Projectile.Center + Projectile.velocity;
                        Vector2 value = mountedCenter.DirectionFrom(target).SafeNormalize(Vector2.Zero);

                        if (Vector2.Dot(unitVectorTowardsPlayer, value) < 0f)
                        {
                            Projectile.Kill();
                            return;
                        }

                        player.ChangeDir((player.Center.X < Projectile.Center.X).ToDirectionInt());
                        break;
                    }
                    
                case AIState.Ricochet:

                    {
                        if (StateTimer++ >= launchTimeLimit + 5) // Ricochet time limit
                        {
                            CurrentAIState = AIState.Dropping;
                            StateTimer = 0f;
                            Projectile.netUpdate = true;
                        }

                        else
                        {
                            Projectile.velocity.X *= 0.95f;
                            Projectile.velocity.Y += 0.6f;
                            player.ChangeDir((player.Center.X < Projectile.Center.X).ToDirectionInt());
                        }
                        break;
                    }

                case AIState.Dropping:

                    {
                        if (!player.controlUseItem || Projectile.Distance(mountedCenter) > launchRange + 160f) // Max dropped range
                        {
                            CurrentAIState = AIState.ForsedRetracting;
                            StateTimer = 0f;
                            Projectile.netUpdate = true;
                        }

                        else
                        {
                            Projectile.velocity.X *= 0.95f;
                            if (!Projectile.shimmerWet) Projectile.velocity.Y += 0.8f;
                            
                            player.ChangeDir((player.Center.X < Projectile.Center.X).ToDirectionInt());
                            Projectile.localNPCHitCooldown = 10;
                        }
                        break;
                    }

            }

            if (Projectile.shimmerWet && Projectile.velocity.Y > 0f) // Bounces
            {
                Projectile.velocity.Y *= -1f;
                Projectile.netUpdate = true;

                if (Projectile.velocity.Y < -8f) Projectile.velocity.Y = -8f;
            }

            Projectile.direction = (Projectile.velocity.X > 0f).ToDirectionInt();
            Projectile.spriteDirection = Projectile.direction;
            Projectile.ownerHitCheck = shouldOwnerHitCheck;

            if (CurrentAIState == AIState.Ricochet || CurrentAIState == AIState.Dropping)
            {
                if (Projectile.velocity.Length() > 1f) Projectile.rotation = Projectile.velocity.ToRotation() + Projectile.velocity.X * 0.1f;
                                                  else Projectile.rotation += Projectile.velocity.X * 0.1f;
            }

            else
            {
                Vector2 vectorTowardsPlayer = Projectile.DirectionTo(mountedCenter).SafeNormalize(Vector2.Zero);
                Projectile.rotation = vectorTowardsPlayer.ToRotation() + MathHelper.PiOver2;
            }

            Projectile.timeLeft = 2;
            player.heldProj = Projectile.whoAmI;
            player.SetDummyItemTime(2);
            player.itemRotation = Projectile.DirectionFrom(mountedCenter).ToRotation();

            if (Projectile.Center.X < mountedCenter.X) player.itemRotation += (float)Math.PI;

            player.itemRotation = MathHelper.WrapAngle(player.itemRotation);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int impactIntensity = 0;
            Vector2 velocity = Projectile.velocity;
            float bounceFactor = 0.2f;

            if (CurrentAIState == AIState.LaunchingForward || CurrentAIState == AIState.Ricochet) bounceFactor = 0.4f;

            if (CurrentAIState == AIState.Dropping) bounceFactor = 0f;

            if (oldVelocity.X != Projectile.velocity.X)
            {
                if (Math.Abs(oldVelocity.X) > 4f) impactIntensity = 1;

                Projectile.velocity.X = (0f - oldVelocity.X) * bounceFactor;
                CollisionCounter += 1f;
            }

            if (oldVelocity.Y != Projectile.velocity.Y)
            {
                if (Math.Abs(oldVelocity.Y) > 4f) impactIntensity = 1;

                Projectile.velocity.Y = (0f - oldVelocity.Y) * bounceFactor;
                CollisionCounter += 1f;
            }

            if (CurrentAIState == AIState.LaunchingForward)
            {
                CurrentAIState = AIState.Ricochet;
                Projectile.netUpdate = true;
                Point scanAreaStart = Projectile.TopLeft.ToTileCoordinates();
                Point scanAreaEnd = Projectile.BottomRight.ToTileCoordinates();
                impactIntensity = 2;
                Projectile.CreateImpactExplosion(2, Projectile.Center, ref scanAreaStart, ref scanAreaEnd, Projectile.width, out bool causedShockwaves);
                Projectile.CreateImpactExplosion2_FlailTileCollision(Projectile.Center, causedShockwaves, velocity);
                Projectile.position -= velocity;
            }

            if (impactIntensity > 0)
            {
                Projectile.netUpdate = true;
                for (int i = 0; i < impactIntensity; i++)
                {
                    Collision.HitTiles(Projectile.position, velocity, Projectile.width, Projectile.height);
                }
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            }

            if (//CurrentAIState != AIState.UnusedState &&
                CurrentAIState != AIState.Spinning &&
                CurrentAIState != AIState.Ricochet &&
                CurrentAIState != AIState.Dropping &&
                CollisionCounter >= 10f)
            {
                CurrentAIState = AIState.ForsedRetracting;
                Projectile.netUpdate = true;
            }
            return false;
        }

        public override bool? CanDamage()
        {
            if (CurrentAIState == AIState.Spinning && SpinningStateTimer <= 12f) return false;
            return base.CanDamage();
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (CurrentAIState == AIState.Spinning)
            {
                Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
                Vector2 shortestVectorFromPlayerToTarget = targetHitbox.ClosestPointInRect(mountedCenter) - mountedCenter;

                shortestVectorFromPlayerToTarget.Y /= 0.8f;
                return shortestVectorFromPlayerToTarget.Length() <= 55f; // Hit radius - the length of the semi-major radius of the ellipse (the long end)
            }
            return base.Colliding(projHitbox, targetHitbox);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (CurrentAIState == AIState.Spinning) modifiers.SourceDamage *= 1.2f;
            else if (CurrentAIState == AIState.LaunchingForward || CurrentAIState == AIState.Retracting) modifiers.SourceDamage *= 2f;

            modifiers.HitDirectionOverride = (Main.player[Projectile.owner].Center.X < target.Center.X).ToDirectionInt();

            if (CurrentAIState == AIState.Spinning) modifiers.Knockback *= 0.35f; // In 1.4.4, the knockback was increased by 10%
            else if (CurrentAIState == AIState.Dropping) modifiers.Knockback *= 0.5f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 playerArmPosition = Main.GetPlayerArmPosition(Projectile);
            playerArmPosition.Y -= Main.player[Projectile.owner].gfxOffY; // This should be removed once the vanilla bug is fixed

            Rectangle? chainSourceRectangle = null;
            Vector2 chainDrawPosition = Projectile.Center;
            Vector2 vectorFromProjectileToPlayerArms = playerArmPosition.MoveTowards(chainDrawPosition, 4f) - chainDrawPosition;
            Vector2 unitVectorFromProjectileToPlayerArms = vectorFromProjectileToPlayerArms.SafeNormalize(Vector2.Zero);

            float chainSegmentLength = (chainSourceRectangle.HasValue ? chainSourceRectangle.Value.Height : chainTexture.Height()) + 0f; // "0f" - Chain height adjustment
            if (chainSegmentLength == 0) chainSegmentLength = 8; // "8" - something like a const

            float chainLengthRemainingToDraw = vectorFromProjectileToPlayerArms.Length() + chainSegmentLength / 2f;
            while (chainLengthRemainingToDraw > 0f)
            {
                Main.spriteBatch.Draw(chainTexture.Value, chainDrawPosition - Main.screenPosition, chainSourceRectangle,
                                      Lighting.GetColor((int)chainDrawPosition.X / 16, (int)(chainDrawPosition.Y / 16f)),
                                      unitVectorFromProjectileToPlayerArms.ToRotation() + MathHelper.PiOver2,
                                      chainSourceRectangle.HasValue ? (chainSourceRectangle.Value.Size() / 2f) : (chainTexture.Size() / 2f),
                                      1f, SpriteEffects.None, 0f);

                chainDrawPosition += unitVectorFromProjectileToPlayerArms * chainSegmentLength;
                chainLengthRemainingToDraw -= chainSegmentLength;
            }
            return true;
        }

    }

}
