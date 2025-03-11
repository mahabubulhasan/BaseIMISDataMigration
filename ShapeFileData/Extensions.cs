using NetTopologySuite.Geometries;

namespace ShapeFileData;

public static class Extensions
{
    public static DateTime? ConvertToDateTime(this string? date)
    {
        if (DateTime.TryParseExact(date, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime lastEmptiedDate))
        {
            return DateTime.SpecifyKind(lastEmptiedDate, DateTimeKind.Utc);
        }
        return null;
    }

    public static DateTime? ConvertYearToDateTime(this double? year)
    {
        if (year == null || year <= 0)
        {
            return null;
        }

        return DateTime.SpecifyKind(new DateTime(Convert.ToInt32(year), 1, 1), DateTimeKind.Utc);
    }

    public static DateTime? ConvertYearToDateTime(this string? year)
    {
        if (string.IsNullOrWhiteSpace(year) || year == "0")
        {
            return null;
        }

        if (int.TryParse(year, out int yearValue) && yearValue > 0)
        {
            return DateTime.SpecifyKind(new DateTime(yearValue, 1, 1), DateTimeKind.Utc);
        }

        return null;
    }

    public static MultiPolygon? Force2D(this MultiPolygon? geometry)
    {
        if (geometry == null)
        {
            return null;
        }

        return GeometryHelper.ConvertTo2D(geometry);
    }

    /// <summary>
    /// Converts the ward string (Ward-02) to an integer (2).
    /// </summary>
    /// <param name="ward"></param>
    /// <returns></returns>
    public static int ToWardNo(this string? ward)
	{
        if (string.IsNullOrEmpty(ward) || ward.Length < 7)
        {
            return 0;
        }
		return int.Parse(ward.Substring(5, 2));
	}
}
