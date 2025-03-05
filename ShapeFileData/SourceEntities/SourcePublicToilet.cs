using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.SourceEntities;

[Table("Public_Toilet_Info", Schema = "public")]
public class SourcePublicToilet
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom", TypeName = "geometry(multipolygon, 4326)")]
    public MultiPolygon? Geometry { get; set; }

    [Column("ID_FID")]
    public long? IdFid { get; set; }

    [Column("Name")]
    public string? Name { get; set; }

    [Column("No_Male")]
    public double? NoMale { get; set; }

    [Column("No_Female")]
    public double? NoFemale { get; set; }

    [Column("F_Handicap")]
    public string? FHandicap { get; set; }

    [Column("Indicative")]
    public string? Indicative { get; set; }

    [Column("Ward_No")]
    public double? WardNo { get; set; }

    [Column("Toilets")]
    public double? Toilets { get; set; }

    [Column("Location")]
    public string? Location { get; set; }

    [Column("Sanitary")]
    public string? Sanitary { get; set; }

    [Column("Owner")]
    public string? Owner { get; set; }

    [Column("Operator")]
    public string? Operator { get; set; }

    [Column("Fees")]
    public string? Fees { get; set; }

    [Column("Caretaker")]
    public string? Caretaker { get; set; }

    [Column("Gender")]
    public string? Gender { get; set; }

    [Column("Contact")]
    public double? Contact { get; set; }

    [Column("ChildFesi")]
    public string? ChildFesi { get; set; }

    [Column("Comments")]
    public string? Comments { get; set; }

    [Column("Surveyor")]
    public string? Surveyor { get; set; }

    [Column("OpenT")]
    public string? OpenTime { get; set; }

    [Column("CloseT")]
    public string? CloseTime { get; set; }

    [Column("NameID")]
    public string? NameId { get; set; }

    [Column("UID")]
    public string? Uid { get; set; }

    [Column("F_Facility")]
    public string? FFacility { get; set; }

    [Column("Owner_name")]
    public string? OwnerName { get; set; }

    [Column("BIN")]
    public string? Bin { get; set; }
}
