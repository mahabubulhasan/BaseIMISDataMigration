using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.SourceEntities;

[Table("Buildings", Schema = "public")]
public class SourceBuilding2
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("geom", TypeName = "geometry(multipolygonz, 4326)")]
    public MultiPolygon? Geometry { get; set; }

    [Column("Build_Type")]
    public string? BuildType { get; set; }

    [Column("Owner_name")]
    public string? OwnerName { get; set; }

    [Column("Gender")]
    public string? Gender { get; set; }

    [Column("Contact_No")]
    public double? ContactNo { get; set; }

    [Column("Struc_type")]
    public string? StructType { get; set; }

    [Column("Floor")]
    public double? Floor { get; set; }

    [Column("Link_Main")]
    public double? LinkMain { get; set; }

    [Column("Func_Use")]
    public string? FuncUse { get; set; }

    [Column("Ward")]
    public double? Ward { get; set; }

    [Column("OfficeNm")]
    public string? OfficeName { get; set; }

    [Column("Male")]
    public double? Male { get; set; }

    [Column("Female")]
    public double? Female { get; set; }

    [Column("Others")]
    public double? Others { get; set; }

    [Column("DisabledM")]
    public double? DisabledMale { get; set; }

    [Column("DisabledFe")]
    public double? DisabledFemale { get; set; }

    [Column("DisabledOt")]
    public double? DisabledOthers { get; set; }

    [Column("TotalPpl")]
    public double? TotalPeople { get; set; }

    [Column("ContLoc")]
    public string? ContLoc { get; set; }

    [Column("TaxMatch")]
    public string? TaxMatch { get; set; }

    [Column("ConstTime")]
    public double? ConstructionTime { get; set; }

    [Column("Household")]
    public double? Household { get; set; }

    [Column("WaterSourc")]
    public string? WaterSource { get; set; }

    [Column("WellDis")]
    public double? WellDis { get; set; }

    [Column("ToiletNum")]
    public double? ToiletNum { get; set; }

    [Column("ToiletHous")]
    public double? ToiletHousehold { get; set; }

    [Column("ToiletPop")]
    public double? ToiletPopulation { get; set; }

    [Column("Well")]
    public string? Well { get; set; }

    [Column("SW")]
    public string? SW { get; set; }

    [Column("ToiletSt")]
    public string? ToiletStatus { get; set; }

    [Column("ConType")]
    public string? ConType { get; set; }

    [Column("SharedBIN")]
    public string? SharedBin { get; set; }

    [Column("Desludger")]
    public string? Desludger { get; set; }

    [Column("Connection")]
    public string? Connection { get; set; }

    [Column("gmt")]
    public string? Gmt { get; set; }

    [Column("Length")]
    public double? Length { get; set; }

    [Column("width")]
    public double? Width { get; set; }

    [Column("Depth")]
    public double? Depth { get; set; }

    [Column("Dia")]
    public double? Dia { get; set; }

    [Column("Volume")]
    public double? Volume { get; set; }

    [Column("Constr")]
    public double? Constr { get; set; }

    [Column("LastEmp")]
    public string? LastEmp { get; set; }

    [Column("Compliance")]
    public string? Compliance { get; set; }

    [Column("SepticCham")]
    public string? SepticCham { get; set; }

    [Column("Defecation")]
    public string? Defecation { get; set; }

    [Column("CommToilet")]
    public string? CommToilet { get; set; }

    [Column("Defecati_1")]
    public string? Defecati1 { get; set; }

    [Column("WaterID")]
    public string? WaterId { get; set; }

    [Column("Road")]
    public double? Road { get; set; }

    [Column("Holding")]
    public string? Holding { get; set; }

    [Column("LastEmpDt")]
    public string? LastEmpDate { get; set; }

    [Column("BIN")]
    public string? Bin { get; set; }

    [Column("LIC")]
    public string? Lic { get; set; }

    [Column("LIC_Name")]
    public string? LicName { get; set; }

    [Column("Road_UID")]
    public string? RoadUid { get; set; }

    [Column("Address")]
    public string? Address { get; set; }

    [Column("Sub_BIN")]
    public string? SubBin { get; set; }

    [Column("WS_Pipe")]
    public string? WsPipe { get; set; }

    [Column("DrainID")]
    public string? DrainId { get; set; }

    [Column("ContConn")]
    public string? ContConn { get; set; }

    [Column("use_cat")]
    public string? UseCategory { get; set; }

    [InverseProperty("SourceBuilding")]
    public virtual ICollection<SourceContainment2>? Containment { get; set; }
}
