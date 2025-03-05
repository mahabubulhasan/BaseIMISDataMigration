using System;
using NetTopologySuite.Geometries;

namespace ShapeFileData;

// Add this class to your project
public class DbGeometry
{
    public MultiPolygon? Geometry { get; set; }

    // Add conversion operators
    public static implicit operator DbGeometry?(Geometry? geometry)
    {
        if (geometry == null)
            return null;

        return new DbGeometry {
            Geometry = geometry as MultiPolygon ??
                      (geometry is Polygon polygon ?
                       new MultiPolygon([polygon]) : null)
        };
    }

    public static implicit operator Geometry?(DbGeometry? dbGeometry)
    {
        return dbGeometry?.Geometry;
    }
}
