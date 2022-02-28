using HarmonyLib;
using UnityEngine;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Sirillion.
//	Tweaked: 

//	Changes the hard coded sprite and color values to fit SMX theme.
//	Difference: Vanilla has hard coded sprite and color values for the set and share waypoint popups which clash with the SMX theme.

public class SMXui_MapPopupEntry
{
	[HarmonyPatch(typeof(XUiC_MapPopupEntry))]
	[HarmonyPatch("OnHovered")]
	public class SMXuiMapPopupEntry
	{
		public static void Postfix(ref XUiC_MapPopupEntry __instance, ref bool _isOver)
		{
			XUiV_Sprite xuiV_Sprite = (XUiV_Sprite)__instance.GetChildById("background").ViewComponent;
			if (xuiV_Sprite != null)
			{
				xuiV_Sprite.Color = (_isOver ? new Color32(96, 96, 96, byte.MaxValue) : new Color32(175, 30, 25, byte.MaxValue));
				xuiV_Sprite.SpriteName = (_isOver ? "smxui_button_background" : "smxui_button_background");
			}
		}
	}
}