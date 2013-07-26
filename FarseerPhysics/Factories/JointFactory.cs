﻿using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using Microsoft.Xna.Framework;

namespace FarseerPhysics.Factories
{
    /// <summary>
    /// An easy to use factory for using joints.
    /// </summary>
    public static class JointFactory
    {
        #region Revolute Joint

        public static RevoluteJoint CreateRevoluteJoint(World world, Body bodyA, Vector2 localAnchorA, Body bodyB, Vector2 localAnchorB)
        {
            RevoluteJoint joint = new RevoluteJoint(bodyA, localAnchorA, bodyB, localAnchorB);
            world.AddJoint(joint);
            return joint;
        }

        /// <summary>
        /// Creates a revolute joint and adds it to the world
        /// </summary>
        /// <param name="world"></param>
        /// <param name="bodyA"></param>
        /// <param name="bodyB"></param>
        /// <param name="localAnchorB"></param>
        /// <returns></returns>
        public static RevoluteJoint CreateRevoluteJoint(World world, Body bodyA, Body bodyB, Vector2 localAnchorB)
        {
            Vector2 localanchorA = bodyA.GetLocalPoint(bodyB.GetWorldPoint(localAnchorB));
            RevoluteJoint joint = new RevoluteJoint(bodyA, localanchorA, bodyB, localAnchorB);
            world.AddJoint(joint);
            return joint;
        }

        ///// <summary>
        ///// Creates the fixed revolute joint.
        ///// </summary>
        ///// <param name="world">The world.</param>
        ///// <param name="body">The body.</param>
        ///// <param name="bodyAnchor">The body anchor.</param>
        ///// <param name="worldAnchor">The world anchor.</param>
        ///// <returns></returns>
        //public static FixedRevoluteJoint CreateFixedRevoluteJoint(World world, Body body, Vector2 bodyAnchor,
        //                                                          Vector2 worldAnchor)
        //{
        //    FixedRevoluteJoint fixedRevoluteJoint = new FixedRevoluteJoint(body, bodyAnchor, worldAnchor);
        //    world.AddJoint(fixedRevoluteJoint);
        //    return fixedRevoluteJoint;
        //}

        #endregion

        #region Weld Joint

        /// <summary>
        /// Creates a weld joint
        /// </summary>
        /// <param name="bodyA"></param>
        /// <param name="bodyB"></param>
        /// <param name="worldAnchor">World space coordinates of weld joint</param>
        /// <returns></returns>
        public static WeldJoint CreateWeldJoint(Body bodyA, Body bodyB, Vector2 worldAnchor)
        {
            WeldJoint joint = new WeldJoint(bodyA, bodyB, bodyA.GetLocalPoint(worldAnchor),
                                            bodyB.GetLocalPoint(worldAnchor));
            return joint;
        }

        /// <summary>
        /// Creates a weld joint and adds it to the world
        /// </summary>
        /// <param name="world"></param>
        /// <param name="bodyA"></param>
        /// <param name="bodyB"></param>
        /// <param name="worldAnchor">World space coordinates of weld joint</param>
        /// <returns></returns>
        public static WeldJoint CreateWeldJoint(World world, Body bodyA, Body bodyB, Vector2 worldAnchor)
        {
            WeldJoint joint = CreateWeldJoint(bodyA, bodyB, worldAnchor);
            world.AddJoint(joint);
            return joint;
        }

        public static WeldJoint CreateWeldJoint(World world, Body bodyA, Body bodyB, Vector2 localAnchorA,
                                                Vector2 localAnchorB)
        {
            WeldJoint weldJoint = new WeldJoint(bodyA, bodyB, localAnchorA, localAnchorB);
            world.AddJoint(weldJoint);
            return weldJoint;
        }

        #endregion

        #region Prismatic Joint

        /// <summary>
        /// Creates a prismatic joint and adds it to the world
        /// </summary>
        /// <param name="world"></param>
        /// <param name="bodyA"></param>
        /// <param name="bodyB"></param>
        /// <param name="anchor"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static PrismaticJoint CreatePrismaticJoint(World world, Body bodyA, Body bodyB, Vector2 anchor, Vector2 axis)
        {
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, anchor, axis);
            world.AddJoint(joint);
            return joint;
        }

        //public static FixedPrismaticJoint CreateFixedPrismaticJoint(World world, Body body, Vector2 worldAnchor,
        //                                                            Vector2 axis)
        //{
        //    FixedPrismaticJoint joint = new FixedPrismaticJoint(body, worldAnchor, axis);
        //    world.AddJoint(joint);
        //    return joint;
        //}

        #endregion

        #region Wheel Joint

        /// <summary>
        /// Creates a Wheel Joint and adds it to the world
        /// </summary>
        public static WheelJoint CreateWheelJoint(World world, Body bodyA, Body bodyB, Vector2 anchorB, Vector2 axis)
        {
            WheelJoint joint = new WheelJoint(bodyA, bodyB, anchorB, axis);
            world.AddJoint(joint);
            return joint;
        }

        public static WheelJoint CreateWheelJoint(World world, Body bodyA, Body bodyB, Vector2 axis)
        {
            return CreateWheelJoint(world, bodyA, bodyB, Vector2.Zero, axis);
        }

        #endregion

        #region Angle Joint

        /// <summary>
        /// Creates an angle joint.
        /// </summary>
        /// <param name="world">The world.</param>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <returns></returns>
        public static AngleJoint CreateAngleJoint(World world, Body bodyA, Body bodyB)
        {
            AngleJoint angleJoint = new AngleJoint(bodyA, bodyB);
            world.AddJoint(angleJoint);

            return angleJoint;
        }

        /// <summary>
        /// Creates a fixed angle joint.
        /// </summary>
        /// <param name="world">The world.</param>
        /// <param name="body">The body.</param>
        /// <returns></returns>
        public static FixedAngleJoint CreateFixedAngleJoint(World world, Body body)
        {
            FixedAngleJoint angleJoint = new FixedAngleJoint(body);
            world.AddJoint(angleJoint);

            return angleJoint;
        }

        #endregion

        #region Distance Joint

        public static DistanceJoint CreateDistanceJoint(World world, Body bodyA, Body bodyB, Vector2 anchorA, Vector2 anchorB)
        {
            DistanceJoint distanceJoint = new DistanceJoint(bodyA, bodyB, anchorA, anchorB);
            world.AddJoint(distanceJoint);
            return distanceJoint;
        }

        public static DistanceJoint CreateDistanceJoint(World world, Body bodyA, Body bodyB)
        {
            return CreateDistanceJoint(world, bodyA, bodyB, Vector2.Zero, Vector2.Zero);
        }

        //public static FixedDistanceJoint CreateFixedDistanceJoint(World world, Body body, Vector2 localAnchor,
        //                                                          Vector2 worldAnchor)
        //{
        //    FixedDistanceJoint distanceJoint = new FixedDistanceJoint(body, localAnchor, worldAnchor);
        //    world.AddJoint(distanceJoint);
        //    return distanceJoint;
        //}

        #endregion

        #region Friction Joint

        public static FrictionJoint CreateFrictionJoint(World world, Body bodyA, Body bodyB, Vector2 anchor)
        {
            FrictionJoint frictionJoint = new FrictionJoint(bodyA, bodyB, anchor);
            world.AddJoint(frictionJoint);
            return frictionJoint;
        }

        public static FrictionJoint CreateFrictionJoint(World world, Body bodyA, Body bodyB)
        {
            return CreateFrictionJoint(world, bodyA, bodyB, Vector2.Zero);
        }

        //public static FixedFrictionJoint CreateFixedFrictionJoint(World world, Body body, Vector2 bodyAnchor)
        //{
        //    FixedFrictionJoint frictionJoint = new FixedFrictionJoint(body, bodyAnchor);
        //    world.AddJoint(frictionJoint);
        //    return frictionJoint;
        //}

        #endregion

        #region Gear Joint

        public static GearJoint CreateGearJoint(World world, Joint jointA, Joint jointB, float ratio)
        {
            GearJoint gearJoint = new GearJoint(jointA, jointB, ratio);
            world.AddJoint(gearJoint);
            return gearJoint;
        }

        #endregion

        #region Pulley Joint

        public static PulleyJoint CreatePulleyJoint(World world, Body bodyA, Body bodyB, Vector2 groundAnchorA, Vector2 groundAnchorB, Vector2 anchorA, Vector2 anchorB, float ratio)
        {
            PulleyJoint pulleyJoint = new PulleyJoint(bodyA, bodyB, groundAnchorA, groundAnchorB, anchorA, anchorB, ratio);
            world.AddJoint(pulleyJoint);
            return pulleyJoint;
        }

        #endregion

        public static FixedMouseJoint CreateFixedMouseJoint(World world, Body body, Vector2 target)
        {
            FixedMouseJoint joint = new FixedMouseJoint(body, target);
            world.AddJoint(joint);
            return joint;
        }
    }
}