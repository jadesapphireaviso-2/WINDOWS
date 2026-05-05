# 🪟 WINDOWS

> *They say the eyes are the windows to the soul.*

**WINDOWS** is a slow, atmospheric 3D walking game where the player navigates through their own mind while in a coma. Moving through three stages of memory — adolescence, young adulthood, and the day of the accident — the player must collect keys that will eventually open the final window: their own eyes.

This is not a game about speed or combat. It is a game about slowing down, looking around, and choosing to keep going.

---

## 🎮 Concept

The player is in a coma. The game takes place entirely in their mind.

Each stage is built from memory — imperfect, slightly too warm, slightly off. The player explores these spaces, interacts with memory fragments, and pieces together who they are and what their life means to them. Completing each stage rewards a key. All three keys lead to a final control room where the player can open the last window and wake up.

**Theme:** *Your eyes are the windows to your soul.*

---

## 🕹️ How to Play

| Action | Key |
|---|---|
| Walk | `W A S D` |
| Switch Camera (1st ↔ 3rd person) | `C` |
| Interact / Examine | `E` |
| Look around | Mouse |

There is **no running**. The player has one speed: walking. Take your time.

### Stages
1. **Early Light** — Childhood. A backyard at golden hour. Find the memory fragments hidden in the neighborhood.
2. **Static** — Young adulthood. A school hallway bleeding into a dorm room. Face unfinished moments.
3. **The Day** — The accident. Walk toward it, not away. Sit down. Accept it.
4. **The Control Room** — Insert all three keys. Press the button. Open your eyes.

### Win & Lose Conditions
- **Wake up** — Insert all three keys into the control panel and press OPEN.
- **Choose rest** — Sit on the couch in the final room and confirm. A quieter ending. Not a failure — a different choice.

---

## 🛠️ Building & Running the Project

### Requirements
- [Unity Hub](https://unity.com/download)
- Unity **2022.3 LTS** or newer
- Render Pipeline: **3D Built-In Render Pipeline**

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/windows-game.git
   ```
2. Open **Unity Hub** → click **Add** → select the cloned project folder
3. Open the project in Unity
4. In the Project panel, navigate to `Assets/Scenes/` and open `Stage1`
5. Press **Play** to run in the editor

### Building for Desktop
1. Go to **File → Build Settings**
2. Select your platform (Windows / Mac / Linux)
3. Click **Add Open Scenes** to include all stages
4. Click **Build**

---

## 📁 Project Structure

> ⚠️ **Note to self:** Clean up and finalize this folder structure when the game is complete. Some folders may shift as the project grows.

```
Assets/
├── Scenes/             # One scene per stage
│   ├── Stage1.unity
│   ├── Stage2.unity
│   ├── Stage3.unity
│   └── ControlRoom.unity
├── Scripts/            # All C# game logic
│   ├── PlayerMovement.cs
│   ├── CameraSwitcher.cs
│   ├── PlayerInteract.cs
│   ├── MemoryFragment.cs
│   └── StageManager.cs
├── Prefabs/            # Reusable GameObjects
├── Materials/          # Colors and textures
├── Audio/              # Ambient sounds, memory sounds, music
└── Models/             # 3D assets and environment pieces
```

---

---

## 💡 Inspiration

This game was inspired by the idea that recovering from something difficult requires facing it — not escaping it. The window metaphor runs throughout: windows as eyes, as memory, as the boundary between where you are and where you could be.

---

*Made with Unity. Built-In Render Pipeline.*
