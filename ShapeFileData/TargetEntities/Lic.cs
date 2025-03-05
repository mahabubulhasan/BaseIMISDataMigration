using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace ShapeFileData.TargetEntities;

[Table("low_income_communities", Schema = "layer_info")]
public class Lic
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("community_name")]
    public string? CommunityName { get; set; }

    [Column("geom")]
    public MultiPolygon? Geometry { get; set; }

    [Column("no_of_buildings")]
    public int? NoOfBuildings { get; set; }

    [Column("number_of_households")]
    public int? NumberOfHouseholds { get; set; }

    [Column("population_total")]
    public int? PopulationTotal { get; set; }

    [Column("population_male")]
    public int? PopulationMale { get; set; }

    [Column("population_female")]
    public int? PopulationFemale { get; set; }

    [Column("population_others")]
    public int? PopulationOthers { get; set; }

    [Column("no_of_septic_tank")]
    public int? NoOfSepticTank { get; set; }

    [Column("no_of_holding_tank")]
    public int? NoOfHoldingTank { get; set; }

    [Column("no_of_pit")]
    public int? NoOfPit { get; set; }

    [Column("no_of_sewer_connection")]
    public int? NoOfSewerConnection { get; set; }

    [Column("no_of_community_toilets")]
    public int? NoOfCommunityToilets { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

}
