using System.Diagnostics;
using HarmonyLib;

[HarmonyPatch(typeof(GameLoad), "AutoSaveGame")]
static class Patch_AutoSaveGame_SmartDisable
{
  static bool Prefix(CheckpointTypes _Checkpoint)
  {

    if (_Checkpoint != CheckpointTypes.Latest)
    {
      // UnityEngine.Debug.Log("允许了里程碑存档:" + _Checkpoint);
      return true;
    }

    // 获取当前调用栈
    var stackTrace = new StackTrace();
    bool isCalledFromActionRoutine = (bool)(stackTrace.GetFrames()?[2]?.GetMethod()?.DeclaringType.Name.Contains("ActionRoutine"));

    // 如果是 ActionRoutine 触发的，禁止存档（自动存档）
    if (isCalledFromActionRoutine)
    {
      // UnityEngine.Debug.Log("阻止了自动存档");
      return false;
    }

    // UnityEngine.Debug.Log("允许了手动存档");
    return true;
  }
}