using HarmonyLib;
using UnityEngine;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Sirillion.
//	Tweaked: 

//	Changes the hard coded sprite and color values to fit SMX theme.
//	Difference: Vanilla has hard coded sprite and color values for the waypoint entry list which clash with the SMX theme.

public class SMXui_mapwaypointlistentry_xuic
{
    [HarmonyPatch(typeof(XUiC_MapWaypointListEntry))]
    [HarmonyPatch("updateSelected")]
    public class SMXuiMapWaypointListEntryupdateSelected
    {
        public static bool Prefix(ref XUiC_MapWaypointListEntry __instance, ref bool _bHover, ref XUiV_Sprite ___Background, ref bool ___m_bSelected)
        {
			XUiV_Sprite background = ___Background;
			if (background != null)
			{
				if (___m_bSelected)
				{
					background.Color = new Color32(160, 160, 160, byte.MaxValue);
					background.SpriteName = "smxlib_window_button_background";
				}
				else if (_bHover)
				{
					background.Color = new Color32(96, 96, 96, byte.MaxValue);
					background.SpriteName = "smxlib_window_button_background";
				}
				else
				{
					background.Color = new Color32(7, 7, 7, byte.MaxValue);
					background.SpriteName = "smxlib_window_button_background";
				}
			}
			__instance.Tracking.IsVisible = (__instance.Waypoint != null && __instance.Waypoint.bTracked);
			return false;
		}
	}
}