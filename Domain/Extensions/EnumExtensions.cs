namespace Domain.Extensions;

public static class EnumExtensions
{
    public static Dictionary<int, string> ToKeyLookup<T>() where T : Enum
    {
        var enumType = typeof(T);
        var enumValues = Enum.GetValues(enumType);
        var result = new Dictionary<int, string>();
        foreach (var enumValue in enumValues)
        {
            var enumName = Enum.GetName(enumType, enumValue);
            var enumKey = (int)enumValue;

            result.Add(enumKey, enumName);
        }
        return result;
    }
}
