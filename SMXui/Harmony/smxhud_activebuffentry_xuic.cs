using HarmonyLib;
using UnityEngine;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: TormentedEmu.
//	Tweaked: Sirillion.

//	Changes hard coded sprites to be SMX sprites.
//	Difference: Vanilla has these sprites hardcoded so when the action happens the sprite would shift to something else. This prevents that.

public class SMXhud_activebuffentryui_xuic
{
    [HarmonyPatch(typeof(XUiC_ActiveBuffEntry), "SelectedChanged")]
    public class SMXhud_ActiveBuffEntry_SelectedChanged
    {
        public static bool Prefix(ref XUiC_ActiveBuffEntry __instance, bool isSelected, ref XUiV_Sprite ___background)
        {
            if (isSelected)
            {
                __instance.InfoWindow.SetBuffInfo(__instance);
            }

            if (___background != null)
            {
                // this controls the color of the background sprite
                ___background.Color = (isSelected ? new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue) : // Sprite color when selected
                                                    new Color32(96, 96, 96, byte.MaxValue)); // Sprite color when not selected

                // this controls which sprite will be shown when the buff is selected(or clicked on) in the active buff list(Character window)
                ___background.SpriteName = (isSelected ? "smxlib_slot_frame_narrow" : // Sprite to use when buff currently selected
                                                         "smxlib_slot_frame_narrow"); // Sprite to use when buff not selected
            }

            return false;
        }
    }
}