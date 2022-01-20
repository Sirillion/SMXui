using System;
using System.Globalization;
using Audio;
using UnityEngine;
using HarmonyLib;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Sirillion.
//	Assists: sphereii, TormentedEmu.

//	Adds an extra binding to add the ability to hide the slots "background icon" for modded parts in the iteminfopanel window.
//	Difference: Vanilla has no ability to hide this.

//	Adds an extra binding to add the ability to set colors based on locked states in the Item Stacks.
//	Difference: Vanilla has no ability to differentiate the different lock states by color, only icon.

public class SMXui_itemstack_xuic
{
	[HarmonyPatch(typeof(XUiC_ItemStack))]
	[HarmonyPatch("GetBindingValue")]

	public class SMXhudItemStackHasIcon
	{
		public static bool Prefix(ref bool __result, ref string _value, ref string _bindingName, ref ItemStack ___itemStack)
		{
			if (_bindingName == "isempty")
			{
				if (___itemStack.IsEmpty())
					_value = "true";
				else
					_value = "false";
				__result = true;
				return false;
			}
			return true;
		}
	}


/*	// Not ready
	[HarmonyPatch(typeof(XUiC_ItemStack))]
	[HarmonyPatch("GetBindingValue")]
	public class SMXuiItemStackAddBinding
	{
		public static void Postfix(ref bool __result, ref string _value, ref string _bindingName, ref XUiC_ItemStack.StackLockTypes ___stackLockType, ref bool ___attributeLock, ref ItemStack ___itemStack)
		{
			if (_bindingName != null)
			{
				if (_bindingName == "smxstacklockcolor")
				{
					if (___stackLockType == XUiC_ItemStack.StackLockTypes.Quest)
					{
						_value = "255,144,24,255";
					}
					else if (___attributeLock && ___itemStack.IsEmpty())
					{
						_value = "175,30,25,255";
					}
					else
					{
						_value = "255,255,0,255";
					}
					__result = true;
				}

				if (_bindingName == "smxstacklockicon")
				{
					if (___stackLockType == XUiC_ItemStack.StackLockTypes.Quest)
					{
						_value = "ui_game_symbol_quest";
					}
					else
					{
						_value = "";
					}
					__result = true;
				}
			}

		}
	}
*/

	/*	// NOT READY. Attempt to inject an new if statement for when a slot is locked then show this color.
		[HarmonyPatch(typeof(XUiC_ItemStack))]
		[HarmonyPatch("updateBorderColor")]
		public class SMXuiItemStackUpdateBorderColor
		{
			public static void Prefix(ref XUiC_ItemStack __instance, ref bool __result,
									ref Color32 ___SelectionBorderColor, ref Color32 ___attributeLockColor)
			{
				if (__instance.IsLocked)
				{
					___SelectionBorderColor = ___attributeLockColor;
				__result = true;
				}
			}
		}
	*/
}
