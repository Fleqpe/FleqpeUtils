# Unity Game Development Utilities

This repository contains various utilities developed for Unity, designed to simplify game development workflows. Below is a summary of the key utilities and systems included in this repository.

## Utilities

### Lootbox System
A system to implement lootbox mechanics in your game. It supports customizable drop rates, item pools, and rarity levels.

### Cards with Buff and Exchange System(Sprites are not included.)
A dynamic card system where cards can provide buffs to the player. Includes a card exchange mechanic, allowing players to trade cards for different rewards.

### Persistent Singleton MonoBehaviour
A Singleton pattern implemented as a MonoBehaviour, designed to persist across different scenes in Unity. Useful for managers or other persistent systems that need to stay alive throughout the game.

### Singleton Scriptable Object
A Singleton pattern using Scriptable Objects, useful for storing game data or configurations shared across multiple game instances.

### Rarity System (Materials not included)
A flexible system for defining and handling item rarities in your game, easily integrable with loot systems or inventory management.

### Daily Quest System
A daily quest system allowing for recurring tasks that reset each day. Supports different types of quests, tracking player progress, and reward distribution.

### Saving Game Data via JSON
A simple, scalable system for saving and loading game data using JSON. Supports complex data structures and is easily extendable.

## Libraries Used

- **BigDouble**: Utilized for handling large numbers, especially in idle or incremental games.
- **UniTask**: Used for asynchronous operations in Unity, providing a more flexible and efficient approach than traditional coroutines.
- **DOTween**: Used for handling animations and tweening in Unity, offering a powerful and easy-to-use system for smooth transitions.
- **Unity Localization Package**: Used to add different languages.
- **JSON .NET For Unity**: Used for saving game data between sessions.

## Note
Some utilities are dependent on others. Ensure all required dependencies are implemented when integrating multiple systems.

## How to Use

To integrate any of these systems into your Unity project, follow these steps:

1. Clone this repository or copy the relevant scripts into your project.
2. Modify the systems as necessary to fit your game’s requirements.
3. Ensure you have the required libraries (BigDouble and UniTask) installed.
4. Attach the scripts to appropriate GameObjects.
