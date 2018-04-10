#region File Description
//-----------------------------------------------------------------------------
// ExplosionParticleSystem.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Particle3DSample
{
    /// <summary>
    /// Custom particle system for creating the fiery part of the explosions.
    /// </summary>
    class ExplosionParticleSystemComic : ParticleSystem
    {
        public ExplosionParticleSystemComic(Game game, ContentManager content)
            : base(game, content)
        { }


        protected override void InitializeSettings(ParticleSettings settings)
        {
            settings.TextureName = "CFX2_T_ShinyStar";

            settings.MaxParticles = 100;

            settings.Duration = TimeSpan.FromSeconds(2);
            settings.DurationRandomness = 1;

            settings.MinHorizontalVelocity = 20;
            settings.MaxHorizontalVelocity = 30;

            settings.MinVerticalVelocity = -20;
            settings.MaxVerticalVelocity = 20;

            settings.EndVelocity = 0;


            settings.MinColor = new Color(255, 140, 0, 255);
            settings.MaxColor = new Color(255, 140, 0, 255);


            settings.MinRotateSpeed = -1;
            settings.MaxRotateSpeed = 1;

            settings.MinStartSize = 7;
            settings.MaxStartSize = 7;

            settings.MinEndSize = 10;
            settings.MaxEndSize = 10;

            // Use additive blending.
            settings.BlendState = BlendState.Additive;
        }
    }
}
