using System;
using NetTopologySuite.Geometries;

namespace ShapeFileData;

public static class Util
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

    public static MultiPolygon? Force2D(MultiPolygon? geometry)
    {
        if (geometry == null)
        {
            return null;
        }

        return new MultiPolygon(
            [.. geometry.Geometries.Select(g =>
                new Polygon(
                    ((Polygon)g).Shell,
                    ((Polygon)g).Holes
                )
            )],
            geometry.Factory
        );
    }
}
