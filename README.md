# Stop Auto-Save – Card Survival: Fantasy Forest

[![zh](https://img.shields.io/badge/lang-zh-red.svg)](README_zh.md)
[![en](https://img.shields.io/badge/lang-en-blue.svg)](README.md)

> A lightweight BepInEx mod for Card Survival: Fantasy Forest that addresses severe late-game stutter caused by automatic saving, while preserving manual saves, exit saves, and the daily 4 AM milestone auto-save.

## ✨ Key Features

- ⛔ **Disables auto-saves triggered by `ActionRoutine`**  
  The game invokes AutoSaveGame(CheckpointTypes.Latest) through GameManager.ActionRoutine at 10 AM and 10 PM in-game time. These scheduled saves are a major source of late-game stutter, and this mod precisely intercepts them.

- ✅ **Preserves critical save functionality**

  - Manual "Save Game" from the menu ✅
  - Auto-save on game exit ✅
  - **Daily 4 AM milestone checkpoint ✅** (triggered by `AutoSaveGame(CheckpointTypes.CurrentDay)`, unaffected)

- ⚡ **Significantly improves late-game performance**  
  Especially noticeable when you have a large number of cards, NPCs, or complex game states—operations feel much more responsive by skipping the auto-saves at 10 AM and 10 PM.

- 🔌 **Plug-and-play — no configuration needed**  
  Activates automatically upon installation. No settings to tweak.

## 📦 Installation

1. Ensure you have [BepInEx 5](https://github.com/BepInEx/BepInEx/releases) installed (for Unity games).
2. Place this mod’s `.dll` file into the `BepInEx/plugins/` folder inside your game directory.
3. Launch the game — it works immediately.

## ⚠️ Compatibility

- Compatible with most other mods (non-intrusive; only patches save logic).
- Does **not** affect achievements, cloud saves, or save file structure.

## 🛠 Technical Details

Uses Harmony to insert a prefix patch before `GameLoad.AutoSaveGame(CheckpointTypes.Latest)` executes:  
→ If the call stack contains `GameManager.ActionRoutine`, the save is skipped.  
→ All other sources (UI button, exit flow, 4 AM checkpoint) remain fully functional.
