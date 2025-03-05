using NetTopologySuite.Geometries;

namespace ShapeFileData;

public class GeometryHelper
{
    // Method to convert a MultiPolygon with Z coordinates to a MultiPolygon without Z coordinates
    public static MultiPolygon ConvertTo2D(MultiPolygon multiPolygon3D)
    {
        var factory = new GeometryFactory();

        var polygons2D = new Polygon[multiPolygon3D.NumGeometries];

        for (int i = 0; i < multiPolygon3D.NumGeometries; i++)
        {
            var polygon3D = (Polygon)multiPolygon3D.GetGeometryN(i);
            polygons2D[i] = ConvertTo2D(polygon3D, factory);
        }

        return factory.CreateMultiPolygon(polygons2D);
    }

    // Method to convert a Polygon with Z coordinates to a Polygon without Z coordinates
    private static Polygon ConvertTo2D(Polygon polygon3D, GeometryFactory factory)
    {
        var shell = ConvertTo2D(polygon3D.Shell, factory);
        var holes = new LinearRing[polygon3D.NumInteriorRings];

        for (int i = 0; i < polygon3D.NumInteriorRings; i++)
        {
            // Convert LineString to LinearRing
            var interiorRing = polygon3D.GetInteriorRingN(i);
            holes[i] = ConvertLineStringTo2DRing(interiorRing, factory);
        }

        return factory.CreatePolygon(shell, holes);
    }

    // Method to convert a LineString with Z coordinates to a LinearRing without Z coordinates
    private static LinearRing ConvertLineStringTo2DRing(LineString lineString3D, GeometryFactory factory)
    {
        var coordinates2D = new Coordinate[lineString3D.NumPoints];

        for (int i = 0; i < lineString3D.NumPoints; i++)
        {
            var coord3D = lineString3D.GetCoordinateN(i);
            coordinates2D[i] = new Coordinate(coord3D.X, coord3D.Y); // Discarding the Z coordinate
        }

        return factory.CreateLinearRing(coordinates2D);
    }

    // Method to convert a LinearRing with Z coordinates to a LinearRing without Z coordinates
    private static LinearRing ConvertTo2D(LinearRing linearRing3D, GeometryFactory factory)
    {
        var coordinates2D = new Coordinate[linearRing3D.NumPoints];

        for (int i = 0; i < linearRing3D.NumPoints; i++)
        {
            var coord3D = linearRing3D.GetCoordinateN(i);
            coordinates2D[i] = new Coordinate(coord3D.X, coord3D.Y); // Discarding the Z coordinate
        }

        return factory.CreateLinearRing(coordinates2D);
    }
}
