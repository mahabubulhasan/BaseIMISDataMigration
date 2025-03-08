using NetTopologySuite.Geometries;

namespace ShapeFileData;

public static class Extensions
{
    public static DateTime? ConvertToDateTime(string? date)
    {
        DateTime.TryParseExact(date, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime lastEmptiedDate);
        return lastEmptiedDate;
    }

    public static DateTime ConvertYearToDateTime(double year)
    {
        return new DateTime(Convert.ToInt32(year), 1, 1);
    }

    public static MultiPolygon? Force2D(this MultiPolygon? geometry)
    {
        if (geometry == null)
        {
            return null;
        }

        return GeometryHelper.ConvertTo2D(geometry);
    }
}
