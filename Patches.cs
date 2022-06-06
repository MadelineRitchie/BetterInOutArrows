using HarmonyLib;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

public class Patches
{
    [HarmonyPatch(typeof(Db))]
    [HarmonyPatch("Initialize")]
    public class Db_Initialize_Patch
    {
        public static void Prefix()
        {
            Debug.Log("I execute before Db.Initialize!");
        }

        public static void Postfix()
        {
            Debug.Log("I execute after Db.Initialize!");
        }
    }
}