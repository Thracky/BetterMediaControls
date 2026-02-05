using HarmonyLib;

namespace BetterMediaControls.util;

public static class ReflectionUtils
{
    public static object GetField(object instance, string fieldName)
    {
        return instance == null
            ? null
            : AccessTools.Field(instance.GetType(), fieldName)
                ?.GetValue(instance);
    }

    public static T GetField<T>(object instance, string fieldName) where T : class
    {
        return GetField(instance, fieldName) as T;
    }
}
