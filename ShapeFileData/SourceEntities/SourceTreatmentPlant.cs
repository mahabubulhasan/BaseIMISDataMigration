using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.SourceEntities;

[Table("Treatment_Plants", Schema = "public")]
public class SourceTreatmentPlant
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom", TypeName = "geometry(point, 32646)")]
    public Point? Geometry { get; set; }

    [Column("Location")]
    public string? Location { get; set; }

    [Column("Type")]
    public string? Type { get; set; }

    [Column("Capacity")]
    public decimal? Capacity { get; set; }

    [Column("Gender")]
    public string? Gender { get; set; }

    [Column("Contact")]
    public string? Contact { get; set; }

    [Column("Notes")]
    public string? Notes { get; set; }

    [Column("Caretaker")]
    public string? Caretaker { get; set; }

    [Column("NamShort")]
    public string? NameShort { get; set; }

    [Column("UID")]
    public string? Uid { get; set; }

    [Column("Ward")]
    public string? Ward { get; set; }
}
