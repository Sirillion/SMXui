using System.Reflection;
using UnityEngine;

public class SMXui : IModApi
{
    public void InitMod(Mod _modInstance)
    {
        Debug.Log($" Loading Patch: {GetType()} Mod: {_modInstance.ModInfo.Name}");
        var harmony = new HarmonyLib.Harmony(GetType().ToString());
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}