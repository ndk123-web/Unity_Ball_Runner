# Learning Runner - Unity Game

## Overview
Learning Runner is an endless runner-style game where the player moves forward automatically and must dodge obstacles while collecting targets to increase their score. The game features a simple yet engaging control mechanism and includes a scoring system, sound effects, environmental effects, and game over mechanics.

## Technologies Used
- **Game Engine:** Unity
- **Programming Language:** C#
- **UI Elements:** TextMeshPro
- **Audio Components:** Unity AudioSource
- **Visual Effects:** Unity Fog, Skybox modifications
- **Game Deployment:** Inno Setup for Windows Executable

---

## Features
### 1. Player Movement
- The player moves forward automatically.
- The player can move **left** or **right** using:
  - Arrow Keys (`←` and `→`)
  - `A` and `D` keys
- Movement is restricted within defined boundaries (`minZ` and `maxZ`).

### 2. UI Elements
- **Score Display:** Keeps track of collected targets.
- **"Tap to Start" Text:** Displays a message before the game begins.
- **Game Over Panel:** Displays when the player collides with an obstacle.
- **Restart & Quit Buttons:** Allow the player to restart or exit the game.

### 3. Collision & Trigger Mechanics
- If the player collides with a wall (tag: `ProperWall` or `LoseWall`), the game ends.
- If the player collects a target (tag: `Target`), their score increases, and the target disappears.

### 4. Sound Effects & Music
- **Background Music** plays throughout the game.
- **Collection Sound** plays when a target is collected.
- **Game Over Sound** plays when the player hits an obstacle.

### 5. Environmental Effects
- **Fog Effect:** Used to create a depth perception effect.
- **Sky Color Change:** The sky dynamically changes color depending on the game’s progress.

---

## Scripts Breakdown

### **PlayerController.cs**
Handles player movement, collision detection, UI updates, and sound effects.

#### Key Functionalities:
- **Start():**
  - Initializes Rigidbody constraints to restrict rotation & Y-movement.
  - Plays background music.
  - Pauses the game until the player presses `Space` or `Enter`.

- **Update():**
  - Handles movement input.
  - Updates player position and restricts movement within boundaries.
  - Toggles game pause/resume with `Space` or `Enter`.

- **FixedUpdate():**
  - Continuously moves the player forward.

- **OnCollisionEnter():**
  - Detects collision with walls and triggers game over.

- **OnTriggerEnter():**
  - Detects when the player collects a target and updates the score.

- **RestartButton() & QuitButton():**
  - Restart reloads the scene.
  - Quit exits the game.

### **CameraController.cs**
Controls the camera movement to follow the player smoothly.

#### Key Functionalities:
- **Start():**
  - Sets an initial offset between the camera and player.

- **LateUpdate():**
  - Updates the camera position based on the player’s position while maintaining the offset.

### **EnvironmentController.cs**
Handles the visual effects such as fog and sky color changes.

#### Key Functionalities:
- **Start():**
  - Initializes fog settings and sky color.

- **Update():**
  - Adjusts the fog density dynamically based on the player’s progress.
  - Modifies the sky color over time to create a changing environment.

---

## How to Play
1. Launch the game in Unity.
2. Press `Space` or `Enter` to start.
3. Use `←` and `→` (or `A` and `D`) to move left/right.
4. Collect targets to increase your score.
5. Avoid hitting obstacles.
6. If you collide with a wall, the game ends.
7. Press "Restart" to play again or "Quit" to exit.

---

## How Unity Converts the Game into an Executable
1. **Build the Game:**
   - In Unity, go to `File > Build Settings`.
   - Choose the target platform (Windows, Mac, Linux, etc.).
   - Click **Build** to generate an executable file.

2. **Optimize Settings:**
   - Adjust quality settings to optimize performance.
   - Compress assets for better load times.

3. **Generate an EXE using Inno Setup:**
   - Use **Inno Setup** to package the game files into an installer.
   - Add dependencies such as Visual C++ Redistributable if required.
   - Customize the installer UI and add license agreements.
   - Compile and distribute the `.exe` file.

---

## Folder & File Structure
```
Learning_Runner/
│── Assets/
│   │── Scripts/
│   │   │── PlayerController.cs
│   │   │── CameraController.cs
│   │   │── EnvironmentController.cs
│   │── UI Elements/
│   │── Audio/
│── .vscode/   # Ignore in Git
│── Assembly-CSharp-Editor.csproj   # Ignore in Git
│── Assembly-CSharp.csproj   # Ignore in Git
│── Learning_Runner.sln   # Ignore in Git
│── README.md
```

---

## Ignore These Files in Git
Add the following to **.gitignore**:
```
.vscode/
Assembly-CSharp-Editor.csproj
Assembly-CSharp.csproj
Learning_Runner.sln
```


