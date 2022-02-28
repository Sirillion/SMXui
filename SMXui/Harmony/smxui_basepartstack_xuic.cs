using HarmonyLib;
using System.Reflection;
using UnityEngine;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: TormentedEmu.
//	Tweaked: Sirillion.

//	Changes hard coded sprites to be SMX sprites.
//	Difference: Vanilla has these sprites hardcoded so when the action happens the sprite would shift to something else. This prevents that.

public class SMXui_basepartstack_xuic
{
    [HarmonyPatch(typeof(XUiC_BasePartStack), "SelectedChanged")]
    public class SMXuiBasePartStackSelectedChanged
    {
        public static bool Prefix(ref XUiC_BasePartStack __instance, bool isSelected, ref Color32 ___selectColor, ref XUiController ___background)
        {
            ((XUiV_Sprite)___background.ViewComponent).Color = (isSelected ? ___selectColor : XUiC_BasePartStack.backgroundColor);
            ((XUiV_Sprite)___background.ViewComponent).SpriteName = (isSelected ? "smxlib_slot_frame_narrow" : "smxlib_slot_frame_narrow");

            return false;
        }
    }
}
