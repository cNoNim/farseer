﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Controllers;

namespace FarseerPhysics.Controllers
{
    /// <summary>
    /// Reference implementation for forces based on AbstractForceController
    /// It supports all features provided by the base class and illustrates proper
    /// usage as an easy to understand example.
    /// As a side-effect it is a nice and easy to use wind force for your projects
    /// </summary>
    public class SimpleWindForce:AbstractForceController
    {
        /// <summary>
        /// Direction of the windforce
        /// </summary>
        public Vector2 Direction { get; set; }

        /// <summary>
        /// The amount of Direction randomization. Allowed range is 0-1.
        /// </summary>
        public float Divergence { get; set; }

        /// <summary>
        /// Ignore the position and apply the force. If off only in the "front" (relative to position and direction)
        /// will be affected
        /// </summary>
        public bool IgnorePosition { get; set; }


        public SimpleWindForce(): base()
        {
        }

        public override void ApplyForce(float dt, float Strength)
        {
            foreach (Body body in this.World.BodyList)
            {
                //TODO: Consider Force Type
                float DecayMultiplier = GetDecayMultiplier(body);

                if (DecayMultiplier != 0)
                {
                    Vector2 forceVector;

                    if (ForceType == ForceTypes.Point)
                    {
                        forceVector = body.Position - Position;
                        
                    }
                    else
                    {
                        Direction.Normalize();

                        forceVector = Direction;

                        if (forceVector.Length() == 0)
                            forceVector = new Vector2(0, 1);
                        
                    }

                    //TODO: Consider Divergence:
                    //forceVector = Vector2.Transform(forceVector, Matrix.CreateRotationZ((MathHelper.Pi - MathHelper.Pi/2) * (float)Randomize.NextDouble()));

                    // Calculate random Variation
                    if (Variation != 0)
                    {
                        float StrengthVariation = (float)Randomize.NextDouble() * MathHelper.Clamp(Variation, 0, 1);
                        forceVector.Normalize();
                        body.ApplyForce(forceVector * Strength * DecayMultiplier * StrengthVariation);
                    }
                    else
                    {
                        forceVector.Normalize();
                        body.ApplyForce(forceVector * Strength * DecayMultiplier);
                    }
                }
            }
        }

    }
}