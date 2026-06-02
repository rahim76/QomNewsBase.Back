using QomNewsBase.Application.Extensions;
using QomNewsBase.Application.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QomNewsBase.Application.Extensions;

public static class EnumExtensions
{
    public static IEnumerable<T> GetEnumValues<T>(this T input) where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new NotSupportedException();

        return Enum.GetValues(input.GetType()).Cast<T>();
    }

    public static IEnumerable<T> GetEnumFlags<T>(this T input) where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new NotSupportedException();

        foreach (var value in Enum.GetValues(input.GetType()))
            if ((input as Enum)!.HasFlag((value as Enum)!))
                yield return (T)value;
    }

    public static string? ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
    {
        Assert.NotNull(value, nameof(value));

        var attribute = value.GetType().GetField(value.ToString())!
            .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

        if (attribute == null)
            return value.ToString();

        var propValue = attribute.GetType().GetProperty(property.ToString())!.GetValue(attribute, null);
        return propValue?.ToString();
    }

    public static Dictionary<int, string?> ToDictionary(this Enum value)
    {
        return Enum.GetValues(value.GetType()).Cast<Enum>().ToDictionary(Convert.ToInt32, q => q.ToDisplay());
    }

    public static TEnum? GetEnumFromDisplayName<TEnum>(this string? displayName) where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(displayName))
            return null;

        foreach (var value in Enum.GetValues(typeof(TEnum)))
        {
            var fieldInfo = typeof(TEnum).GetField(value!.ToString());
            var displayAttr = fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

            var name = displayAttr?.Name ?? value.ToString();

            if (string.Equals(name, displayName, StringComparison.OrdinalIgnoreCase))
                return (TEnum)value;
        }

        return null;
    }

}
public enum DisplayProperty
{
    Description,
    GroupName,
    Name,
    Prompt,
    ShortName,
    Order
}