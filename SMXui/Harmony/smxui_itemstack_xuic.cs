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

	public class SMXuiItemStackHasIcon
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
}