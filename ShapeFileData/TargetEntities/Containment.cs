using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("containments", Schema = "fsm")]
public class Containment
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("type_id")]
    public int? TypeId { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("size")]
    [Precision(10, 2)]
    public decimal? Size { get; set; }

    [Column("pit_diameter")]
    public decimal? PitDiameter { get; set; }

    [Column("tank_length")]
    public decimal? TankLength { get; set; }

    [Column("tank_width")]
    public decimal? TankWidth { get; set; }

    [Column("depth")]
    public decimal? Depth { get; set; }

    [Column("septic_criteria")]
    public bool? SepticCriteria { get; set; }

    [Column("construction_date")]
    public DateTime? ConstructionDate { get; set; }

    [Column("emptied_status")]
    public bool? EmptiedStatus { get; set; }

    [Column("last_emptied_date")]
    public DateTime? LastEmptiedDate { get; set; }

    [Column("next_emptying_date")]
    public DateTime? NextEmptyingDate { get; set; }

    [Column("no_of_times_emptied")]
    public int? NoOfTimesEmptied { get; set; }

    [Column("surveyed_at")]
    public DateTime? SurveyedAt { get; set; }

    [Column("toilet_count")]
    public int? ToiletCount { get; set; }

    [Column("distance_closest_well")]
    public decimal? DistanceClosestWell { get; set; }

    [Column("geom")]
    public Point? Geometry { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("verification_required")]
    public bool? VerificationRequired { get; set; }

    [Column("responsible_bin")]
    public string? ResponsibleBin { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
