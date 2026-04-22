using HarmonyLib;
using System.Linq;
using UnityEngine.UIElements;

namespace IronStash.Patches
{
    [HarmonyPatch(typeof(CL_GameManager), "Start")]
    public class AddStash
    {
        [HarmonyPostfix]
        public static void Postfix(CL_GameManager __instance)
        {
            var whitelist = new string[] { "item_injector", "item_pillbottle", "denizen_sluggrub", "item_food_bar" };

            if (CL_GameManager.GetBaseGamemode().IsIronKnuckle())
            {
                for (int i = 0; i < SettingsManager.settings.competitiveSettings.lockerItems.Count; i++)
                {
                    Item_Object itemObjectPrefab = CL_AssetManager.GetItemObjectPrefab(SettingsManager.settings.competitiveSettings.lockerItems[i]);
                    if (itemObjectPrefab != null && whitelist.Contains(itemObjectPrefab.itemData.itemName))
                    {
                        string data = SettingsManager.settings.competitiveSettings.lockerItems[i];
                        CL_GameManager.SetGameFlag("equiplocker-" + CL_GameManager.GetBaseGamemode().GetGamemodeName() + "local" + (i + 1), state: true, data);
                    }
                }
            }

        }
    }
}
