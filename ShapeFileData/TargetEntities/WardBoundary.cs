using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("wardboundary", Schema = "layer_info")]
public class WardBoundary
{
    [Key]
    [Column("ward")]
    public int WardNumber { get; set; }

    [Column("area")]
    public double? Area { get; set; }

    [Column("geom")]
    public MultiPolygon? Geometry { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
