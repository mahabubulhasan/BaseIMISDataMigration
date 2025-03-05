using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("buildings", Schema = "building_info")]
public class Building
{
    [Key]
    [StringLength(254)]
    [Column("bin")]
    public string Bin { get; set; } = null!;

    [StringLength(254)]
    [Column("building_associated_to")]
    public string? BuildingAssociatedTo { get; set; }

    [Column("ward")]
    public int? Ward { get; set; }

    [StringLength(254)]
    [Column("road_code")]
    public string? RoadCode { get; set; }

    [Column("house_number")]
    public string? HouseNumber { get; set; }

    [Column("house_locality")]
    public string? HouseLocality { get; set; }

    [StringLength(254)]
    [Column("tax_code")]
    public string? TaxCode { get; set; }

    [Column("structure_type_id")]
    public int? StructureTypeId { get; set; }

    [Column("surveyed_date")]
    public DateTime? SurveyedDate { get; set; }

    [Column("floor_count", TypeName = "numeric(10, 2)")]
    public decimal? FloorCount { get; set; }

    [Column("construction_year")]
    public DateTime? ConstructionYear { get; set; }

    [Column("functional_use_id")]
    public int? FunctionalUseId { get; set; }

    [Column("use_category_id")]
    public int? UseCategoryId { get; set; }

    [StringLength(254)]
    [Column("office_business_name")]
    public string? OfficeBusinessName { get; set; }

    [Column("household_served")]
    public int? HouseholdServed { get; set; }

    [Column("population_served")]
    public int? PopulationServed { get; set; }

    [Column("male_population")]
    public int? MalePopulation { get; set; }

    [Column("female_population")]
    public int? FemalePopulation { get; set; }

    [Column("other_population")]
    public int? OtherPopulation { get; set; }

    [Column("diff_abled_male_pop")]
    public int? DiffAbledMalePop { get; set; }

    [Column("diff_abled_female_pop")]
    public int? DiffAbledFemalePop { get; set; }

    [Column("diff_abled_others_pop")]
    public int? DiffAbledOthersPop { get; set; }

    [Column("low_income_hh")]
    public bool? LowIncomeHh { get; set; }

    [Column("lic_id")]
    public int? LicId { get; set; }

    [Column("water_source_id")]
    public int? WaterSourceId { get; set; }

    [StringLength(255)]
    [Column("watersupply_pipe_code")]
    public string? WaterSupplyPipeCode { get; set; }

    [Column("water_customer_id")]
    public string? WaterCustomerId { get; set; }

    [Column("well_presence_status")]
    public bool? WellPresenceStatus { get; set; }

    [Column("distance_from_well")]
    public decimal? DistanceFromWell { get; set; }

    [Column("swm_customer_id")]
    public string? SwmCustomerId { get; set; }

    [Column("toilet_status")]
    public bool? ToiletStatus { get; set; }

    [Column("toilet_count")]
    public int? ToiletCount { get; set; }

    [Column("household_with_private_toilet")]
    public int? HouseholdWithPrivateToilet { get; set; }

    [Column("population_with_private_toilet")]
    public int? PopulationWithPrivateToilet { get; set; }

    [Column("sanitation_system_id")]
    public int? SanitationSystemId { get; set; }

    [StringLength(254)]
    [Column("sewer_code")]
    public string? SewerCode { get; set; }

    [StringLength(254)]
    [Column("drain_code")]
    public string? DrainCode { get; set; }

    [Column("desludging_vehicle_accessible")]
    public bool? DesludgingVehicleAccessible { get; set; }

    [Column("geom", TypeName = "geometry(multipolygon, 4326)")]
    public MultiPolygon? Geometry { get; set; }

    [Column("verification_status")]
    public bool? VerificationStatus { get; set; }

    [Column("estimated_area", TypeName = "numeric(10, 2)")]
    public decimal? EstimatedArea { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }
}
