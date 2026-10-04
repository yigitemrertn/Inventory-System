# TBOI-Style Modular Inventory & Stat System (Unity)

This project is a scalable and modular 2D inventory and stat management system designed for "The Binding of Isaac" (TBOI) style roguelike games, developed using the Unity engine. 

The primary goal of this architecture is to avoid highly coupled, spaghetti-code structures (God Objects) by establishing a clean, modular foundation based on the **"Single Source of Truth"** principle.

## 🚀 Core Features & Architecture

* **Centralized Stat Management (Single Source of Truth):** 
  Character stats like movement speed, damage, and luck are not scattered across multiple behavior scripts. All components (e.g., `PlayerMovement`) dynamically fetch their required stat data from the centralized `PlayerStat` manager during every physics step.
* **Data Isolation via ScriptableObjects (Base vs. Runtime Data):** 
  Item data and base character stats are templated using `ScriptableObjects` (Read-Only). Upon game initialization, these templates are copied into a runtime-only Dictionary (`currStats`). This completely prevents the common Unity "ScriptableObject data persistence" issue in the editor.
* **Dynamic Modifier System:** 
  Instead of hardcoding stats (e.g., `public int hp`, `int dmg`), they are managed using a Dictionary/Enum-based structure. Adding a new stat type to the game requires zero code changes in existing scripts.
* **Encapsulation & Independent Object Logic:** 
  Ground items do not directly manipulate the player's stats upon collision. They simply pass their data payload to the `Inventory` system and destroy themselves. The actual stat math is hierarchically delegated to the core manager (`PlayerStat`).
* **New Input System:**
  Player movement is implemented using Unity's modern, event-driven New Input System package.

## 🛠 Tech Stack
* **Game Engine:** Unity 2022+ (2D)
* **Language:** C#
* **Key Concepts:** ScriptableObjects, Dictionaries, New Input System, Physics2D, OOP Design Patterns.

## 🎮 How It Works
1. The character (`PlayerMovement`) moves in a 2D plane using the New Input System, fetching its current speed directly from `PlayerStat`.
2. Upon colliding with an `Item` object in the world, the object destroys itself and passes its `ItemData` (ScriptableObject) template to the player's `Inventory` component.
3. The `Inventory` reads the modifiers inside the item's `.affectedStats` dictionary and commands the `PlayerStat` manager to update the runtime stats.
4. The character's speed, damage, or relevant stat is updated instantly and safely.
