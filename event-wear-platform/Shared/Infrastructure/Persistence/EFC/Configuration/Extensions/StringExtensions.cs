using Humanizer;

namespace event_wear_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string text)
    {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;
            yield return char.ToLower(e.Current);

            while (e.MoveNext()) 
                if (char.IsUpper(e.Current))
                {
                    yield return '-';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
        }
    }

    public static string ToPlural(this string text)
    {
        return text.Pluralize(inputIsKnownToBeSingular: false);
    }
}