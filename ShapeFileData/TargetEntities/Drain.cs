using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("drains", Schema = "utility_info")]
public class Drain
{
    [Key]
    [Column("code")]
    public string Code { get; set; } = null!;

    [Column("road_code")]
    public string? RoadCode { get; set; }

    [Column("cover_type")]
    public string? CoverType { get; set; }

    [Column("surface_type")]
    public string? SurfaceType { get; set; }

    [Column("size")]
    public decimal? Size { get; set; }

    [Column("length")]
    public decimal? Length { get; set; }

    [Column("treatment_plant_id")]
    public int? TreatmentPlantId { get; set; }

    [Column("geom")]
    public MultiLineString? Geometry { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
