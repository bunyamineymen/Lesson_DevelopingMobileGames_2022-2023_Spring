using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDescription<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        FieldInfo? fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        if (fieldInfo == null)
            return string.Empty;
            
        DescriptionAttribute? descriptionAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
        if (descriptionAttribute != null)
            return descriptionAttribute.Description;


        return enumValue.ToString();
    }
}

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        // This is a very simple extension method. It purpose is Title Case a string.
        if (str.Length > 0)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
        return str;
    }
}

public static class EnumerableExtension{
     //This method returns the mode of a list of values.
    public static IEnumerable<T> Mode<T>(this IEnumerable<T> list)
    {
        var groups = list.GroupBy(i => i);
        var maxCount = groups.Max(g => g.Count());
        return groups.Where(g => g.Count() == maxCount).Select(g => g.Key);
    }
}

public static class TestExtensions
{
    public static void Test()
    {
        string testString = "hello world";
        var result = testString.ToTitleCase();
        Console.WriteLine(result); // Hello world


        var mode = new[] {1,1,1,1,5,6,7,8,9}.Mode(); // 1
        var mode2 = new[] {1,1,1,1,5,5,5,5,6,7,8,9}.Mode(); // 1, 5
        var modestr = new[] {"a","a","a","a","b","c","d","e","f"}.Mode(); // a
        
        foreach (var item in mode2)
        {
            Console.WriteLine(item);
        }
    }
}

