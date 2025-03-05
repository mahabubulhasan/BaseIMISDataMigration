using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("toilets", Schema = "fsm")]
public class Toilet
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("ward")]
    public int? Ward { get; set; }

    [Column("location_name")]
    public string? LocationName { get; set; }

    [Column("bin")]
    public string? Bin { get; set; }

    [Column("access_frm_nearest_road")]
    public int? AccessFromNearestRoad { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("caretaker_name")]
    public string? CaretakerName { get; set; }

    [Column("caretaker_gender")]
    public string? CaretakerGender { get; set; }

    [Column("caretaker_contact_number")]
    public long? CaretakerContactNumber { get; set; }

    [Column("owner")]
    public string? Owner { get; set; }

    [Column("owning_institution_name")]
    public string? OwningInstitutionName { get; set; }

    [Column("operator_or_maintainer")]
    public string? OperatorOrMaintainer { get; set; }

    [Column("operator_or_maintainer_name")]
    public string? OperatorOrMaintainerName { get; set; }

    [Column("total_no_of_toilets")]
    public int? TotalNumberOfToilets { get; set; }

    [Column("total_no_of_urinals")]
    public int? TotalNumberOfUrinals { get; set; }

    [Column("male_or_female_facility")]
    public bool? MaleOrFemaleFacility { get; set; }

    [Column("male_seats")]
    public int? MaleSeats { get; set; }

    [Column("female_seats")]
    public int? FemaleSeats { get; set; }

    [Column("handicap_facility")]
    public bool? HandicapFacility { get; set; }

    [Column("pwd_seats")]
    public int? PwdSeats { get; set; }

    [Column("children_facility")]
    public bool? ChildrenFacility { get; set; }

    [Column("separate_facility_with_universal_design")]
    public bool? SeparateFacilityWithUniversalDesign { get; set; }

    [Column("indicative_sign")]
    public bool? IndicativeSign { get; set; }

    [Column("sanitary_supplies_disposal_facility")]
    public bool? SanitarySuppliesDisposalFacility { get; set; }

    [Column("fee_collected")]
    public bool? FeeCollected { get; set; }

    [Column("amount_of_fee_collected")]
    public decimal? AmountOfFeeCollected { get; set; }

    [Column("frequency_of_fee_collected")]
    public string? FrequencyOfFeeCollected { get; set; }

    [Column("geom")]
    public Point? Geometry { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
