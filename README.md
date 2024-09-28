# Flappy Bird - University Course Project

## Game Description

This project is a simplified version of the **Flappy Bird** game built using Unity as part of a university course project. The player controls a bird that moves upwards when the mouse is clicked, trying to avoid randomly spawned obstacles (pipes) by passing through gaps between them. Each successful pass increases the player's score, which is displayed on the screen.

### Main Features:
- **Player Control**: The bird flaps and moves upward when the player clicks the mouse.
- **Obstacles**: Randomly spawned pairs of pipes appear with varying vertical positions, creating gaps for the bird to pass through.
- **Score**: The player's score increases when they successfully navigate through the pipes.

---

## Changes and Implementations

### 1. **Trigger Collider for Scoring**
   - A trigger collider was added between the upper and lower pipes in the obstacles prefab.
   - When the bird passes through the gap between the pipes, the trigger detects the event and increases the player's score.
   - The bird's script (`Player.cs`) handles the collision with the trigger, updating the score accordingly.

### 2. **Score UI**
   - A UI element was added using **Text** to display the score on the screen.
   - The score is linked directly to the bird's script, and each time the bird passes through the trigger, the score increases.

### 3. **Bird Animation**
   - The bird animation was implemented using 3 different sprites.
   - The sprites are switched to simulate a flapping motion when the player clicks the mouse.
   - The animation is triggered and controlled via the bird’s script, making the bird appear to flap while ascending.

### 4. **Rotation Fix**
   - Rotation occurring by collision of bird with obstacles was fixed.
   - RigidBody2D constraints was edited to freeze the rotation of bird.
