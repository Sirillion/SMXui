using HarmonyLib;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Sirillion.
//	Tweaked: 

//	Adds an extra binding to change the hard coded colors to fit with the SMX color scheme.
//	Difference: Vanilla has hard coded color values for the SkillEntry which clash with the SMX color scheme.

public class SMXui_SkillEntry_ColorCorrection
{

	//	Correcting the colors for perk rowstates.
	[HarmonyPatch(typeof(XUiC_SkillEntry))]
	[HarmonyPatch("GetBindingValue")]
	public class SMXuiSkillEntry
	{
		public static void Postfix(ref bool __result, ref string value, ref string bindingName, ref bool ___isSelected, ref bool ___IsHovered, ref string ___hoverColor, ref ProgressionValue ___currentSkill, ref string ___rowColor)
		{
            if (bindingName != null)
            {
                if (bindingName == "smxrowstatecolor")
                {
                    value = (___isSelected ? "160,160,160" : (___IsHovered ? ___hoverColor : ((___currentSkill != null && ___currentSkill.ProgressionClass.IsAttribute) ? "160,160,160" : ___rowColor)));
                    __result = true;
                }
            }
        }
	}
}