using System;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.SourceEntities;

[Table("Containments", Schema = "public")]
public class SourceContainment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom", TypeName = "geometry(point, 4326)")]
    public Point? Geometry { get; set; }

    [Column("ContLoc")]
    public string? ContLoc { get; set; }

    [Column("ToiletSt")]
    public string? ToiletStatus { get; set; }

    [Column("Desludger")]
    public string? Desludger { get; set; }

    [Column("Length")]
    public string? Length { get; set; }

    [Column("width")]
    public string? Width { get; set; }

    [Column("Depth")]
    public string? Depth { get; set; }

    [Column("Dia")]
    public string? Dia { get; set; }

    [Column("Volume")]
    public string? Volume { get; set; }

    [Column("Constr")]
    public string? Constr { get; set; }

    [Column("Compliance")]
    public string? Compliance { get; set; }

    [Column("SepticCham")]
    public string? SepticChamber { get; set; }

    [Column("BIN")]
    public string? Bin { get; set; }

    [Column("ContConn")]
    public string? ContConn { get; set; }

    [Column("fid_1")]
    public double? Fid1 { get; set; }

    [Column("UID")]
    public string? Uid { get; set; }

    [Column("LastEmpDt")]
    public string? LastEmptyDate { get; set; }

    [Column("Connecti_1")]
    public string? Connection { get; set; }

    [InverseProperty("Containment")]
    [ForeignKey("Bin")]
    virtual public SourceBuilding? SourceBuilding { get; set; }
}
