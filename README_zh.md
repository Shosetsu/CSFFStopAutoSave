# 禁止自动存档 - 《卡牌生存：奇幻森林》Mod

[![zh](https://img.shields.io/badge/lang-zh-red.svg)](README_zh.md)
[![en](https://img.shields.io/badge/lang-en-blue.svg)](README.md)

> 专为《卡牌生存：奇幻森林》（Card Survival: Fantasy Forest）设计的轻量级 BepInEx Mod，**解决游戏后期因频繁自动存档导致的严重卡顿**，同时**保留手动存档、退出存档以及每日 4 点的里程碑自动存档**。

## ✨ 功能特点

- ⛔ **禁用 `ActionRoutine` 触发的自动存档**  
  游戏会通过 `GameManager.ActionRoutine`在游戏时间 10 点与 22 点时调用 `AutoSaveGame(CheckpointTypes.Latest)`，这是后期卡顿的一大原因，本 Mod 精准拦截此类调用。

- ✅ **保留关键存档功能**

  - 手动点击“保存游戏” ✅
  - 退出游戏时的自动保存 ✅
  - **每日凌晨 4 点的里程碑存档（Checkpoint）✅**（该存档由`AutoSaveGame(CheckpointTypes.CurrentDay)`触发，不受影响）

- ⚡ **显著提升后期流畅度**  
  尤其在拥有大量卡牌、NPC 或复杂状态的中后期，通过跳过 10 点和 22 点的自动保存，使操作更跟手。

- 🔌 **即装即用，无需配置**  
  安装后自动生效，无任何设置项。

## 📦 安装方法

1. 确保已安装 [BepInEx 5](https://github.com/BepInEx/BepInEx/releases)（适用于 Unity 游戏）。
2. 将本 Mod 的 `.dll` 文件放入游戏目录下的 `BepInEx/plugins/` 文件夹中。
3. 启动游戏即可。

## ⚠️ 兼容性

- 与大多数其他 Mod 兼容（因仅 patch 存档逻辑，无侵入性修改）。
- **不会影响成就、云存档或存档文件结构**。

## 🛠 技术原理

通过 Harmony 在 `GameLoad.AutoSaveGame(CheckpointTypes.Latest)` 方法执行前插入判断：  
仅当调用栈包含 `GameManager.ActionRoutine` 时，才跳过存档操作。  
其他来源（如 UI 按钮、退出流程、每日 4 点检查点）均不受影响。
