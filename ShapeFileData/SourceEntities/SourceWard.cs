using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.SourceEntities;

[Table("Ward_boundary", Schema = "public")]
public class SourceWard
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom", TypeName = "geometry(multipolygon, 4326)")]
    public MultiPolygon? Geometry { get; set; }

    [Column("Name")]
    [StringLength(25)]
    public string? Name { get; set; }

    [Column("Area_Km2")]
    public double? AreaKm2 { get; set; }

    [Column("Ward_No")]
    public long? WardNo { get; set; }

    [Column("UID")]
    [StringLength(16)]
    public string? Uid { get; set; }

    [Column("Ward_Num")]
    [StringLength(16)]
    public string? WardNum { get; set; }
}
