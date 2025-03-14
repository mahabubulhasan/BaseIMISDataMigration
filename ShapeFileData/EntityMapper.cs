using ShapeFileData.SourceEntities;
using ShapeFileData.TargetEntities;

namespace ShapeFileData;

public static class EntityMapper
{
    public static Road MapRoad(SourceRoad row) => new()
    {
        Code = row.Uid ?? string.Empty,
        Name = row.RoadName,
        Hierarchy = row.RoadClass,
        RightOfWay = row.WidthInMeters.HasValue ? (decimal?)row.WidthInMeters.Value : null,
        CarryingWidth = row.CarriageInMeters.HasValue ? (decimal?)row.CarriageInMeters.Value : null,
        SurfaceType = row.Surface,
        Length = row.LengthInMeters.HasValue ? (decimal?)row.LengthInMeters.Value : null,
        Geometry = row.Geometry?.Force2D(),
    };

    public static Drain MapDrain(SourceDrain row) => new()
    {
        Code = row.DrainId ?? string.Empty,
        RoadCode = row.RoadUid,
        CoverType = row.DrainageCover,
        SurfaceType = row.DrainageStructure,
        Size = row.DrainWidthM.HasValue ? (decimal?)row.DrainWidthM.Value : null,
        Length = row.LengthM.HasValue ? (decimal?)row.LengthM.Value : null,
        Geometry = row.Geometry,
    };

    public static Ward MapWard(SourceWard row) => new()
    {
        WardNumber = row.WardNo.HasValue ? (int)row.WardNo.Value : 0,
        Area = row.AreaKm2,
        Geometry = row.Geometry,
    };

    public static WardBoundary MapWardBoundary(SourceWard row) => new()
    {
        WardNumber = row.WardNo.HasValue ? (int)row.WardNo.Value : 0,
        Area = row.AreaKm2,
        Geometry = row.Geometry,
    };

    public static Lic MapLic(SourceLic row) => new()
    {
        Id = int.TryParse(row.Uid, out int licId) ? licId : 0,
        CommunityName = row.Name,
        NoOfBuildings = row.Buildings.HasValue ? (int?)row.Buildings.Value : null,
        NumberOfHouseholds = row.Household.HasValue ? (int?)row.Household.Value : null,
        PopulationTotal = row.TotalPopulation.HasValue ? (int?)row.TotalPopulation.Value : null,
        PopulationMale = row.Male.HasValue ? (int?)row.Male.Value : null,
        PopulationFemale = row.Female.HasValue ? (int?)row.Female.Value : null,
        PopulationOthers = row.Others.HasValue ? (int?)row.Others.Value : null,
        NoOfSepticTank = row.SepticTank.HasValue ? (int?)row.SepticTank.Value : null,
        NoOfPit = row.Pit.HasValue ? (int?)row.Pit.Value : null,
        NoOfCommunityToilets = row.CommunityToilet.HasValue ? (int?)row.CommunityToilet.Value : null,
        Geometry = row.Geometry,
    };

    public static TreatmentPlant MapTreatmentPlant(SourceTreatmentPlant row) => new()
    {
        Name = row.Uid,
        Ward = row.Ward.ToWardNo(),
        Location = row.Location,
        Type = int.TryParse(row.Type, out int typeValue) ? (int?)typeValue : null,
        CapacityPerDay = row.Capacity,
        CaretakerName = row.Caretaker,
        CaretakerGender = row.Gender,
        CaretakerNumber = !string.IsNullOrEmpty(row.Contact) && long.TryParse(row.Contact, out long number) ? number : null,
        Geometry = row.Geometry,
        Status = row.Status?.Equals("Operational", StringComparison.OrdinalIgnoreCase) == true,
    };

    public static Toilet MapToilet(SourceCommunityToilet row) => new()
    {
        Name = row.Name,
        Type = "Community Toilet",
        Ward = row.WardNo.HasValue ? (int?)row.WardNo.Value : null,
        LocationName = row.Location,
        Bin = row.Bin,
        CaretakerName = row.Caretaker,
        CaretakerGender = row.Gender,
        CaretakerContactNumber = row.Contact.HasValue ? (long?)row.Contact.Value : null,
        Owner = row.Owner,
        OperatorOrMaintainer = row.Operator,
        TotalNumberOfToilets = row.Toilets.HasValue ? (int?)row.Toilets.Value : null,
        SanitarySuppliesDisposalFacility = row.Sanitary?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        FeeCollected = row.Fees?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        Geometry = row.Geometry?.Centroid, // Point = MultiPolygon
        Status = row.Status?.Equals("Operational", StringComparison.OrdinalIgnoreCase) == true,
        OwningInstitutionName = row.OwnIns,
        OperatorOrMaintainerName = row.OperIns

    };

    public static Toilet MapToilet(SourcePublicToilet row) => new()
    {
        Name = row.Name +" "+ row.Id,
        Type = "Public Toilet",
        Ward = row.WardNo.HasValue ? (int?)row.WardNo.Value : null,
        LocationName = row.Location,
        Bin = row.Bin,
        CaretakerName = row.Caretaker,
        CaretakerGender = row.Gender,
        CaretakerContactNumber = row.Contact.HasValue ? (long?)row.Contact.Value : null,
        Owner = row.Owner,
        OperatorOrMaintainer = row.Operator,
        TotalNumberOfToilets = row.Toilets.HasValue ? (int?)row.Toilets.Value : null,
        MaleOrFemaleFacility = row.FFacility?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        MaleSeats = row.NoMale.HasValue ? (int?)row.NoMale.Value : null,
        FemaleSeats = row.NoFemale.HasValue ? (int?)row.NoFemale.Value : null,
        HandicapFacility = row.FHandicap?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        ChildrenFacility = row.ChildFesi?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        IndicativeSign = row.Indicative?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        SanitarySuppliesDisposalFacility = row.Sanitary?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        FeeCollected = row.Fees?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        Geometry = row.Geometry?.Centroid, // Point = MultiPolygon
        Status = row.Status?.Equals("Operational", StringComparison.OrdinalIgnoreCase) == true,
        OwningInstitutionName = row.OwnIns,
        OperatorOrMaintainerName = row.OperIns
    };

    public static Owner MapOwner(SourceBuilding row) => new()
    {
        Bin = row.Bin,
        OwnerName = row.OwnerName ?? "N/A",
        OwnerGender = row.Gender ?? "Others",
        OwnerContact = row.ContactNo.HasValue
            ? (row.ContactNo.Value.ToString().Length == 10
                ? long.Parse("0" + row.ContactNo.Value)
                : (long?)row.ContactNo.Value)
            : 999,
    };

    public static Containment MapContainment(SourceContainment row)
    {
        Containment containment = new(){
            Id = $"C{row.Id:D6}",
            TypeId = DataQuery.GetContainmentTypeId(row.ContConn),
            Geometry = row.Geometry,
            Location = row.ContLoc,
            Size = decimal.TryParse(row.Volume, out decimal volume) ? (decimal?)volume : null,
            PitDiameter = decimal.TryParse(row.Dia, out decimal dia) ? (decimal?)dia : null,
            TankLength = decimal.TryParse(row.Length, out decimal length) ? (decimal?)length : null,
            TankWidth = decimal.TryParse(row.Width, out decimal width) ? (decimal?)width : null,
            Depth = decimal.TryParse(row.Depth, out decimal depth) ? (decimal?)depth : null,
            SepticCriteria = row.SepticChamber?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
            ConstructionDate = row.Constr.ConvertYearToDateTime(),
            LastEmptiedDate = row.LastEmptyDate?.Equals("Never Emptied", StringComparison.OrdinalIgnoreCase) == true ? null : row.LastEmptyDate.ConvertToDateTime(),
            ResponsibleBin = row.Connection
        };

        var building = row.SourceBuilding;

        if(building != null){
            containment.ToiletCount = building.ToiletNum.HasValue ? (int?)building.ToiletNum.Value : null;
            containment.DistanceClosestWell = building.WellDis.HasValue ? (decimal?)building.WellDis.Value : null;
        }

        return containment;
    }

    public static Building MapBuilding(SourceBuilding row) => new()
    {
        Bin = row.Bin ?? string.Empty,
        BuildingAssociatedTo = row.SubBin,
        Ward = row.Ward.HasValue ? (int?)row.Ward.Value : null,
        RoadCode = row.RoadUid,
        HouseNumber = $"{row.Bin}-{row.Holding}",
        HouseLocality = row.Address,
        TaxCode = row.TaxMatch ?? "999",
        StructureTypeId = DataQuery.GetStructureTypeId(row.StructType),
        FloorCount = row.Floor.HasValue ? (int?)row.Floor.Value : null,
        ConstructionYear = row.ConstructionTime.ConvertYearToDateTime(),
        FunctionalUseId = DataQuery.GetFunctionalUseId(row.FuncUse2),
        UseCategoryId = 68, // default for N/A, seeded by imis
        OfficeBusinessName = row.OfficeName,
        HouseholdServed = row.Household.HasValue ? (int?)row.Household.Value : null,
        PopulationServed = row.TotalPeople.HasValue ? (int?)row.TotalPeople.Value : null,
        MalePopulation = row.Male.HasValue ? (int?)row.Male.Value : null,
        FemalePopulation = row.Female.HasValue ? (int?)row.Female.Value : null,
        OtherPopulation = row.Others.HasValue ? (int?)row.Others.Value : null,
        DiffAbledMalePop = row.DisabledMale.HasValue ? (int?)row.DisabledMale.Value : null,
        DiffAbledFemalePop = row.DisabledFemale.HasValue ? (int?)row.DisabledFemale.Value : null,
        DiffAbledOthersPop = row.DisabledOthers.HasValue ? (int?)row.DisabledOthers.Value : null,
        LowIncomeHh = row.Lic?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        LicId = DataQuery.GetLowIncomeCommunityId(row.LicName),
        WaterSourceId = DataQuery.GetWaterSourceId(row.WaterSource),
        WaterCustomerId = row.WaterId,
        WellPresenceStatus = row.Well?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        DistanceFromWell = row.WellDis.HasValue ? (decimal?)row.WellDis.Value : null,
        ToiletStatus = row.ToiletStatus?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        ToiletCount = row.ToiletNum.HasValue ? (int?)row.ToiletNum.Value : null,
        HouseholdWithPrivateToilet = row.ToiletHousehold.HasValue ? (int?)row.ToiletHousehold.Value : null,
        PopulationWithPrivateToilet = row.ToiletPopulation.HasValue ? (int?)row.ToiletPopulation.Value : null,
        SanitationSystemId = DataQuery.GetSanitationSystemId(row.ConType),
        DrainCode = row.DrainId,
        DesludgingVehicleAccessible = row.Desludger?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        Geometry = row.Geometry.Force2D(),
    };
}
