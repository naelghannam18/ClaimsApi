namespace Domain.Extensions;

public static class ListExtensions
{
    public static bool IsNullOrEmpty<T>(this List<T> source) => source is null || source.Count == 0;
     
    public static bool IsNotNullOrEmpty<T>(this List<T> source) => !source.IsNullOrEmpty();

    public static bool IsNullOrEmpty<T>(this T[] source) => source is null || source.Length == 0;

    public static bool IsNotNullOrEmpty<T>(this T[] source) => !source.IsNullOrEmpty();
}
