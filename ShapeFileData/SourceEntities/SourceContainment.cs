using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using NetTopologySuite.Geometries;

namespace ShapeFileData.SourceEntities;


[Table("Containments", Schema = "public")]
public class SourceContainment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom", TypeName = "geometry(point, 32646)")]
    public Point? Geometry { get; set; }

    [Column("ConType")]
    public string? ConType { get; set; }

    [Column("Connecti_1")]
    public string? Bin { get; set; } // bin

    [InverseProperty("Containment")]
    [ForeignKey("Bin")]
    virtual public SourceBuilding? SourceBuilding { get; set; }
}
