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
    /// Converts a 3D geometry (with Z coordinates) to a 2D geometry by removing the Z dimension
    /// </summary>
    public static MultiLineString? Force2D(this MultiLineString? geometry)
    {
        if (geometry == null)
            return null;

        var factory = new GeometryFactory(geometry.PrecisionModel, geometry.SRID);

        var lineStrings = new LineString[geometry.NumGeometries];

        for (int i = 0; i < geometry.NumGeometries; i++)
        {
            var lineString = (LineString)geometry.GetGeometryN(i);
            var coordinates = lineString.Coordinates;
            var coords2D = new Coordinate[coordinates.Length];

            for (int j = 0; j < coordinates.Length; j++)
            {
                coords2D[j] = new Coordinate(coordinates[j].X, coordinates[j].Y);
            }

            lineStrings[i] = factory.CreateLineString(coords2D);
        }

        return factory.CreateMultiLineString(lineStrings);
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
