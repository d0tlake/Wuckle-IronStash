using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace IronStash;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static new ManualLogSource Logger;

    public void Awake()
    {
        Logger = base.Logger;
        Harmony harmony = new("dotlake.stash");
        harmony.PatchAll();
        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} is loaded");
    }
}
