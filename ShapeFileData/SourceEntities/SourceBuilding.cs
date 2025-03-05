using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.SourceEntities
{
    [Table("Buildings", Schema = "public")]
    public class SourceBuilding
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("geom")]
        public MultiPolygon? Geom { get; set; }

        [Column("BIN")]
        public string? Bin { get; set; }

        [Column("Link_Main")]
        public double? LinkMain { get; set; }

        [Column("Ward")]
        public double? Ward { get; set; }

        [Column("Road_UID")]
        public string? RoadUid { get; set; }

        [Column("Holding")]
        public string? Holding { get; set; }

        [Column("Address")]
        public string? Address { get; set; }

        [Column("TaxMatch")]
        public string? TaxMatch { get; set; }

        [Column("Struc_type")]
        public string? StructType { get; set; }

        [Column("Floor")]
        public double? Floor { get; set; }

        [Column("ConstTime")]
        public double? ConstructionTime { get; set; }

        [Column("Func_Use")]
        public string? FuncUse { get; set; }

        [Column("OfficeNm")]
        public string? OfficeName { get; set; }

        [Column("Household")]
        public double? Household { get; set; }

        [Column("TotalPpl")]
        public double? TotalPeople { get; set; }

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

        [Column("LIC")]
        public string? LowIncome { get; set; }

        [Column("LIC_Name")]
        public string? LowIncomeName { get; set; }

        [Column("WaterSourc")]
        public string? WaterSource { get; set; }

        [Column("WaterID")]
        public string? WaterId { get; set; }

        [Column("Well")]
        public string? Well { get; set; }

        [Column("ToiletSt")]
        public string? ToiletStatus { get; set; }

        [Column("ToiletHous")]
        public double? ToiletHousehold { get; set; }

        [Column("ToiletPop")]
        public double? ToiletPopulation { get; set; }

        [Column("Desludger")]
        public string? Desludger { get; set; }

        // used for owner table
        [Column("Owner_name")]
        public string? Owner { get; set; }

        [Column("Gender")]
        public string? Gender { get; set; }

        [Column("Contact_No")]
        public float? ContactNo { get; set; }

        // used for containment table
        [Column("ConType")]
        public string? ConType { get; set; }

        [Column("ContLoc")]
        public string? ContLoc { get; set; }

        [Column("Volume")]
        public double? Volume { get; set; }

        [Column("Dia")]
        public double? Dia { get; set; }

        [Column("Length")]
        public double? Length { get; set; }

        [Column("width")]
        public double? Width { get; set; }

        [Column("Depth")]
        public double? Depth { get; set; }

        [Column("Compliance")]
        public string? Compliance { get; set; }

        [Column("Constr")]
        public double? Constr { get; set; }

        [Column("LastEmpDt")]
        public string? LastEmpDt { get; set; }

        [Column("ToiletNum")]
        public double? ToiletNum { get; set; }

        [Column("WellDis")]
        public double? WellDis { get; set; }

        [Column("Connection")]
        public string? Connecti_1 { get; set; }

        [InverseProperty("SourceBuilding")]
        public virtual ICollection<SourceContainment>? Containment { get; set; }
    }
}
