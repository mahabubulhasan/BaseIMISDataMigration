using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.SourceEntities;

[Table("Drainage", Schema = "public")]
public class SourceDrain
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom")]
    public MultiLineString? Geometry { get; set; }

    [Column("FID_1")]
    public int? Fid1 { get; set; }

    [Column("fid_1_1")]
    public double? Fid11 { get; set; }

    [Column("DrainID")]
    public string? DrainId { get; set; }

    [Column("RoadID")]
    public string? RoadId { get; set; }

    [Column("Length_m")]
    public long? LengthM { get; set; }

    [Column("Dr_Struc")]
    public string? DrainageStructure { get; set; }

    [Column("Dr_Cover")]
    public string? DrainageCover { get; set; }

    [Column("DrWidthFt")]
    public double? DrainWidthFt { get; set; }

    [Column("DrWidthM")]
    public double? DrainWidthM { get; set; }
}
