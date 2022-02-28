using HarmonyLib;

//	Terms of Use: You can use this file as you want as long as this line and the credit lines are not removed or changed other than adding to them!
//	Credits: Laydor.
//  Tweaked: Sirillion.

//	Changes where the MapEnterWaypoint window opens
//	Difference: Vanilla opens up the MapEnterWaypoint window next to the waypoint icon selected, this opens up the window to below the mapAreaSetWaypoint window.

public class SMXui_mapenterwaypoint_xuic
{
    [HarmonyPatch(typeof(XUiC_MapEnterWaypoint), "Show")]
    public class SMXuiMapEnterWaypointShow
    {
        public static bool Prefix(ref Vector2i _position, XUiC_MapEnterWaypoint __instance)
        {
            XUiV_Window windowMapPopup = __instance.xui.GetWindow("mapAreaSetWaypoint");
            _position = windowMapPopup.Position + new Vector2i(0, -windowMapPopup.Size.y);
            return true;
        }
    }
}
