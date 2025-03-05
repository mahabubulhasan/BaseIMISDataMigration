using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("treatment_plants", Schema = "fsm")]
public class TreatmentPlant
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("ward")]
    public int? Ward { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("type")]
    public int? Type { get; set; }

    [Column("treatment_system")]
    public string? TreatmentSystem { get; set; }

    [Column("treatment_technology")]
    public string? TreatmentTechnology { get; set; }

    [Column("capacity_per_day")]
    [Precision(10, 2)]
    public decimal? CapacityPerDay { get; set; }

    [Column("caretaker_name")]
    public string? CaretakerName { get; set; }

    [Column("caretaker_gender")]
    public string? CaretakerGender { get; set; }

    [Column("caretaker_number")]
    public long? CaretakerNumber { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("geom")]
    public Point? Geometry { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
