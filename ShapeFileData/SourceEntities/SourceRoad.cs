using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.SourceEntities;

[Table("Road_Network", Schema = "public")]
public class SourceRoad
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom", TypeName = "geometry(multilinestringz, 32646)")]
    [NotMapped]
    public MultiLineString? Geometry { get; set; }

    [Column("Rd_Name")]
    [StringLength(254)]
    public string? RoadName { get; set; }

    [Column("Length_m")]
    public double? LengthInMeters { get; set; }

    [Column("Width_ft")]
    public double? WidthInFeet { get; set; }

    [Column("Rd_Class")]
    [StringLength(254)]
    public string? RoadClass { get; set; }

    [Column("Surface")]
    [StringLength(254)]
    public string? Surface { get; set; }

    [Column("Carriage")]
    public double? Carriage { get; set; }

    [Column("Condition")]
    [StringLength(254)]
    public string? Condition { get; set; }

    [Column("RoadID")]
    [StringLength(254)]
    public string? RoadId { get; set; }

    [Column("Width_m")]
    public double? WidthInMeters { get; set; }

    [Column("Carriage_m")]
    public double? CarriageInMeters { get; set; }

    [Column("UID")]
    [StringLength(250)]
    public string? Uid { get; set; }
}

