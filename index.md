---
layout: default
title: What is Farseer Physics Engine?
---

# What is Farseer Physics Engine?

Farseer Physics Engine is a collision detection system with realistic physics responses. This means you can create a game or robotic simulation easily using the engine and the associated tools. Everything from a simple hobby game to a complex robotic simulation is possible with Farseer Physics Engine.

## Features

Farseer Physics Engine is based on Box2D, which means we have a lot of features in common. However, we also have a lot more features that are not included in the Box2D engine.

* Continuous collision detection (with time of impact solver)
* Contact callbacks: begin, end, pre-solve, post-solve
* Convex and concave polyons and circles.
* Multiple shapes per body
* Dynamic tree and quad tree broadphase
* Fast broadphase AABB queries and raycasts
* Collision groups and categories
* Sleep management
* Friction and restitution
* Stable stacking with a linear-time solver
* Revolute, prismatic, distance, pulley, gear, mouse joint, and other joint types
* Joint limits and joint motors
* Controllers (gravity, force generators)
* Tools to decompose concave polygons, find convex hulls and boolean operations
* Factories to simplify the creation of bodies