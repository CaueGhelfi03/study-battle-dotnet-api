namespace TaskSystem.Core.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool SafeAny<T>(this IEnumerable<T>? source) => source?.Any() ?? false;
    }
}
