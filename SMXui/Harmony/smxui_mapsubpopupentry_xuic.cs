using HarmonyLib;
using UnityEngine;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Sirillion.
//	Tweaked: 

//	Changes the hard coded sprite and color values to fit SMX theme.
//	Difference: Vanilla has hard coded sprite and color values for the waypoint entries which clash with the SMX theme.

public class SMXui_mapsubpopupentry_xuic
{

    [HarmonyPatch(typeof(XUiC_MapSubPopupEntry))]
    [HarmonyPatch("select")]
    public class SMXuiMapSubPopupEntryselect
    {
        public static bool Prefix(ref bool _bSelect, ref XUiView ___viewComponent)
        {
            XUiV_Sprite xuiV_Sprite = (XUiV_Sprite)___viewComponent;
            if (xuiV_Sprite != null)
            {
                xuiV_Sprite.Color = (_bSelect ? new Color32(96, 96, 96, byte.MaxValue) : new Color32(64, 64, 64, byte.MaxValue));
                xuiV_Sprite.SpriteName = (_bSelect ? "smxui_button_background" : "smxui_button_background");
            }
            return false;
        }
    }


    //	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
    //	Credits: Laydor.

    //	Changes hard coded sprites to be the sprites provided by the list.
    //	Difference: Vanilla has these sprites hardcoded so it was impossible to add new sprites

    public class SMXui_XUiC_MapSubPopupList
    {
        [HarmonyPatch(typeof(XUiC_MapSubPopupList), "Init")]
        public class MapSubPopupList_Init
        {
            public static bool Prefix(ref string[] ___sprites)
            {
                ___sprites = new string[]
                {
                //Insert new ui icon names here
				"ui_game_symbol_map_waypoint01",
                "ui_game_symbol_map_waypoint02",
                "ui_game_symbol_map_waypoint03",
                "ui_game_symbol_map_waypoint04",
                "ui_game_symbol_map_waypoint05",
                "ui_game_symbol_map_waypoint06",
                "ui_game_symbol_map_waypoint07",
                "ui_game_symbol_map_waypoint08",
                "ui_game_symbol_map_waypoint09",
                "ui_game_symbol_map_waypoint10",
                "ui_game_symbol_map_waypoint11",
                "ui_game_symbol_map_waypoint12",
                "ui_game_symbol_map_waypoint13",
                "ui_game_symbol_map_waypoint14",
                "ui_game_symbol_map_waypoint15",
                "ui_game_symbol_map_waypoint16",
                "ui_game_symbol_map_waypoint17",
                "ui_game_symbol_map_waypoint18",
                "ui_game_symbol_map_waypoint19",
                "ui_game_symbol_map_waypoint20",
                "ui_game_symbol_map_waypoint21",
                "ui_game_symbol_map_waypoint22",
                "ui_game_symbol_map_waypoint23",
                "ui_game_symbol_map_waypoint24",
                "ui_game_symbol_map_waypoint25",
                "ui_game_symbol_map_waypoint26",
                "ui_game_symbol_map_waypoint27",
                "ui_game_symbol_map_waypoint28",
                "ui_game_symbol_map_waypoint29",
                "ui_game_symbol_map_waypoint30",
                "ui_game_symbol_map_waypoint31",
                "ui_game_symbol_map_waypoint32",
                "ui_game_symbol_map_waypoint33",
                "ui_game_symbol_map_waypoint34",
                "ui_game_symbol_map_waypoint35",
                "ui_game_symbol_map_waypoint36",
                "ui_game_symbol_map_waypoint37",
                "ui_game_symbol_map_waypoint38",
                "ui_game_symbol_map_waypoint39",
                "ui_game_symbol_map_waypoint40",
                "ui_game_symbol_map_waypoint41",
                "ui_game_symbol_map_waypoint42",
                "ui_game_symbol_map_waypoint43",
                "ui_game_symbol_map_waypoint44",
                "ui_game_symbol_map_waypoint45",
                "ui_game_symbol_map_waypoint46",
                "ui_game_symbol_map_waypoint47",
                "ui_game_symbol_map_waypoint48"
                };
                return true;
            }
        }
    }
}