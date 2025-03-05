using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.SourceEntities;

[Table("Slum_area", Schema = "public")]
public class SourceLic
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom", TypeName = "geometry(multipolygon, 32646)")]
    public MultiPolygon? Geometry { get; set; }

    [Column("Name")]
    [StringLength(254)]
    public string? Name { get; set; }

    [Column("Status")]
    [StringLength(254)]
    public string? Status { get; set; }

    [Column("Notes")]
    [StringLength(254)]
    public string? Notes { get; set; }

    [Column("Area_m")]
    public double? AreaInSquareMeters { get; set; }

    [Column("UID")]
    [StringLength(16)]
    public string? Uid { get; set; }

    [Column("LIC_Name")]
    [StringLength(254)]
    public string? LicName { get; set; }

    [Column("Buildings")]
    public long? Buildings { get; set; }

    [Column("Male")]
    public long? Male { get; set; }

    [Column("Female")]
    public long? Female { get; set; }

    [Column("Others")]
    public long? Others { get; set; }

    [Column("TotalPop")]
    public long? TotalPopulation { get; set; }

    [Column("Household")]
    public long? Household { get; set; }

    [Column("Pit")]
    public long? Pit { get; set; }

    [Column("Septic_Tan")]
    public long? SepticTank { get; set; }

    [Column("CommToilet")]
    public long? CommunityToilet { get; set; }
}
