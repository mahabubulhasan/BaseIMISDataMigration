using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("roads", Schema = "utility_info")]
public class Road
{
    [Key]
    [Column("code")]
    public string Code { get; set; } = null!;

    [Column("name")]
    public string? Name { get; set; }

    [Column("hierarchy")]
    public string? Hierarchy { get; set; }

    [Column("right_of_way")]
    public decimal? RightOfWay { get; set; }

    [Column("carrying_width")]
    public decimal? CarryingWidth { get; set; }

    [Column("surface_type")]
    public string? SurfaceType { get; set; }

    [Column("length")]
    public decimal? Length { get; set; }

    [Column("geom")]
    [NotMapped]
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
