using System.Runtime.InteropServices.JavaScript;

namespace FACDataMiner.Utilities.Extensions;

public static class StringHelpers
{
    public static string? ToStringOrNullValue(this string source)
    {
        return string.IsNullOrEmpty(source) ? null : source;
    }

    public static DateTime? ToDateTimeOrNullValue(this string source, string format)
    {
        return string.IsNullOrEmpty(source) ? null : DateTime.ParseExact(source, format, null);
    }

    public static short? ToShortOrNullValue(this string source)
    {
        return string.IsNullOrEmpty(source) ? null : short.Parse(source);        
    }
    
    public static bool? ToBooleanOrNullValue(this string source)
    {

        if (!string.IsNullOrEmpty(source))
        {
            if (source.ToLower() == "yes" || source.ToLower() == "y")
            {
                source = "true";
            }

            if (source.ToLower() == "no" || source.ToLower() == "n")
            {
                source = "false";
            }
        }
        
        return string.IsNullOrEmpty(source) ? null : bool.Parse(source);
    }

    public static int? ToIntOrNullValue(this string source)
    {
        return string.IsNullOrEmpty(source) ? null : int.Parse(source);
    }
    
    public static decimal? ToDecimalOrNullValue(this string source)
    {
        return string.IsNullOrEmpty(source) ? null : decimal.Parse(source);
    }
    
    
}