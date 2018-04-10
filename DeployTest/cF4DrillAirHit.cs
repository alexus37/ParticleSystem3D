#region File Description
//-----------------------------------------------------------------------------
// SmokePlumeParticleSystem.cs
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
    /// Custom particle system for creating a giant plume of long lasting smoke.
    /// </summary>
    class CF4DrillAirHit : ParticleSystem
    {
        public CF4DrillAirHit(Game game, ContentManager content)
            : base(game, content)
        { }


        protected override void InitializeSettings(ParticleSettings settings)
        {
            settings.TextureName = "CF4DrillAirHit";

            settings.MaxParticles = 30;

            settings.Duration = TimeSpan.FromSeconds(3);

            settings.MinHorizontalVelocity = 0;
            settings.MaxHorizontalVelocity = 15;

            settings.MinVerticalVelocity = 10;
            settings.MaxVerticalVelocity = 20;

            // Create a wind effect by tilting the gravity vector sideways.
            settings.Gravity = new Vector3(0, -50, 0);

            settings.MinColor = new Color(139, 69, 19, 255);
            settings.MaxColor = new Color(205, 133, 63, 50);

            settings.EndVelocity = 0.75f;

            settings.MinRotateSpeed = -1;
            settings.MaxRotateSpeed = 1;

            settings.MinStartSize = 4;
            settings.MaxStartSize = 7;

            settings.MinEndSize = 35;
            settings.MaxEndSize = 50;
        }
    }
}
