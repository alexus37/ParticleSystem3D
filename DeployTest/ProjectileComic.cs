#region File Description
//-----------------------------------------------------------------------------
// Projectile.cs by alex
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
#endregion

namespace Particle3DSample
{
    /// <summary>
    /// This class demonstrates how to combine several different particle systems
    /// to build up a more sophisticated composite effect. It implements a rocket
    /// projectile, which arcs up into the sky using a ParticleEmitter to leave a
    /// steady stream of trail particles behind it. After a while it explodes,
    /// creating a sudden burst of explosion and smoke particles.
    /// </summary>
    class ProjectileComic
    {
        #region Constants

        const float trailParticlesPerSecond = 200;
        const int numExplosionParticles = 30;
        const int numExplosionSmokeParticles = 50;
        const int numProjectiles = 10;
        const float projectileLifespan = 1.5f;
        const float sidewaysVelocityRange = 40;
        const float verticalVelocityRange = 40;
        const float gravity = 15;

        #endregion

        #region Fields

        ParticleSystem explosionParticles;
        ParticleSystem explosionSmokeParticles;
        List<ParticleEmitter> trailEmitters = new List<ParticleEmitter>();
    

        
        List<Vector3> position = new List<Vector3>();
        List<Vector3> velocities = new List<Vector3>();
        
        float age;

        static Random random = new Random();

        #endregion


        /// <summary>
        /// Constructs a new projectile.
        /// </summary>
        public ProjectileComic(ParticleSystem explosionParticles,
                          ParticleSystem explosionSmokeParticles,
                          ParticleSystem projectileTrailParticles)
        {
            this.explosionParticles = explosionParticles;
            this.explosionSmokeParticles = explosionSmokeParticles;

            

            for (int i = 0; i < numProjectiles; i++)
            {
                position.Add(new Vector3(0, 60, 0));

                Vector3 velocity = new Vector3();
                velocity.X = (float)(random.NextDouble() - 0.5) * sidewaysVelocityRange;
                velocity.Y = (float)(random.NextDouble() - 0.1) * verticalVelocityRange;
                velocity.Z = (float)(random.NextDouble() - 0.5) * sidewaysVelocityRange;
                velocities.Add(velocity);

                // Use the particle emitter helper to output our trail particles.
                ParticleEmitter trailEmitter = new ParticleEmitter(projectileTrailParticles, trailParticlesPerSecond, position[i]);
                trailEmitters.Add(trailEmitter);
            }
               
        }


        /// <summary>
        /// Updates the projectile.
        /// </summary>
        public bool Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            age += elapsedTime;
            for (int i = 0; i < numProjectiles; i++)
            {
                // Simple projectile physics.
                position[i] += velocities[i] * elapsedTime;
                velocities[i] = velocities[i] - new Vector3(0, elapsedTime * gravity, 0);


                // Update the particle emitter, which will create our particle trail.
                trailEmitters[i].Update(gameTime, position[i]);

                // If enough time has passed, explode! Note how we pass our velocity
                // in to the AddParticle method: this lets the explosion be influenced
                // by the speed and direction of the projectile which created it.
                if (age > projectileLifespan)
                {
                    for (int j = 0; j < numExplosionParticles; j++)
                        explosionParticles.AddParticle(position[i], velocities[i]);

                    for (int j = 0; j < numExplosionSmokeParticles; j++)
                        explosionSmokeParticles.AddParticle(position[i], velocities[i]);

                    return false;
                }

                return true;
            }
            return true;
                
        }
    }
}
