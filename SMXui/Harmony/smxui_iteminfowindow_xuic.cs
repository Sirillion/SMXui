using HarmonyLib;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: TormentedEmu.
//	Tweaked: .

//	Reserves the item modification parts list slot 0 to a cosmetic mod whether it exists or not
//	Difference: If there is no cosmetic mod, all the remaining installed mods will shift to slot 1

public class SMXui_XUiC_ItemInfoWindow
{
    public static ItemStack PartListItemStack = ItemStack.Empty.Clone();
    public static bool HasCosmeticMods = false;

    [HarmonyPatch(typeof(XUiC_PartList), "SetMainItem")]
    public class SMXui_XUiC_PartList_SetMainItem
    {
        public static void Postfix(ref XUiC_PartList __instance, ItemStack itemStack)
        {
            PartListItemStack = itemStack.Clone();

            if (PartListItemStack.itemValue.CosmeticMods != null && PartListItemStack.itemValue.CosmeticMods.Length > 0 && PartListItemStack.itemValue.CosmeticMods[0] != null)
                HasCosmeticMods = true;
            else
                HasCosmeticMods = false;
        }
    }

    [HarmonyPatch(typeof(XUiC_PartList), "SetSlots")]
    public class SMXui_XUiC_PartList_SetSlots
    {
        public static void Prefix(ref XUiC_PartList __instance, ItemValue[] parts, ref int startIndex)
        {
            if (startIndex == 0 && HasCosmeticMods)
            {
                __instance.SetSlot(PartListItemStack.itemValue.CosmeticMods[0], 0);
                startIndex = 1;
            }
        }
    }

}
