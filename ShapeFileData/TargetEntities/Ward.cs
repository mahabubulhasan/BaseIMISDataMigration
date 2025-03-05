using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("wards", Schema = "layer_info")]
public class Ward
{
    [Key]
    [Column("ward")]
    public int WardNumber { get; set; }

    [Column("area")]
    public double? Area { get; set; }

    [Column("geom", TypeName = "geometry(multipolygon,4326)")]
    public MultiPolygon? Geometry { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
