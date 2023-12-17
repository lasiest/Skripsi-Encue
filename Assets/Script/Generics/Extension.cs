using System.Linq;

public static class Extension
{
    public static bool In<T>(this T argument, params T[] arguments) => arguments.Contains(argument);
}