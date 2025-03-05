using ShapeFileData.SourceEntities;
using ShapeFileData.TargetEntities;

namespace ShapeFileData;

public static class EntityBuilder
{
    public static Road BuildRoad(SourceRoad row) => new()
    {
        Code = row.Uid ?? string.Empty,
        Name = row.RoadName,
        Hierarchy = row.RoadClass,
        RightOfWay = row.WidthInMeters.HasValue ? (decimal?)row.WidthInMeters.Value : null,
        CarryingWidth = row.CarriageInMeters.HasValue ? (decimal?)row.CarriageInMeters.Value : null,
        SurfaceType = row.Surface,
        Length = row.LengthInMeters.HasValue ? (decimal?)row.LengthInMeters.Value : null,
        Geometry = row.Geometry,
    };

    public static Drain BuildDrain(SourceDrain row) => new()
    {
        Code = row.DrainId ?? string.Empty,
        // RoadCode = row.RoadId, // TODO: Need to add Road first.
        CoverType = row.DrainageCover,
        SurfaceType = row.DrainageStructure,
        Size = row.DrainWidthM.HasValue ? (decimal?)row.DrainWidthM.Value : null,
        Length = row.LengthM.HasValue ? (decimal?)row.LengthM.Value : null,
        Geometry = row.Geometry,
    };

    public static Ward BuildWard(SourceWard row) => new()
    {
        WardNumber = row.WardNo.HasValue ? (int)row.WardNo.Value : 0,
        Area = row.AreaKm2,
        Geometry = row.Geometry,
    };

    public static WardBoundary BuildWardBoundary(SourceWard row) => new()
    {
        WardNumber = row.WardNo.HasValue ? (int)row.WardNo.Value : 0,
        Area = row.AreaKm2,
        Geometry = row.Geometry,
    };

    public static Lic BuildLic(SourceLic row) => new()
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

    public static TreatmentPlant BuildTreatmentPlant(SourceTreatmentPlant row) => new()
    {
        Name = row.Uid,
        // Ward = sourceTreatmentPlant.Ward,
        Location = row.Location,
        // Type = sourceTreatmentPlant.Type,
        CapacityPerDay = row.Capacity,
        CaretakerName = row.Caretaker,
        CaretakerGender = row.Gender,
        CaretakerNumber = !string.IsNullOrEmpty(row.Contact) && long.TryParse(row.Contact, out long number) ? number : null,
        Geometry = row.Geometry,
    };

    public static Toilet BuildToilet(SourceCommunityToilet row) => new()
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
    };

    public static Toilet BuildToilet(SourcePublicToilet row) => new()
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
    };

    public static Owner BuildOwner(SourceBuilding row) => new()
    {
        Bin = row.Bin,
        OwnerName = row.Owner,
        OwnerGender = row.Gender,
        OwnerContact = row.ContactNo.HasValue ? (long?)row.ContactNo.Value : null,
    };

    public static Containment BuildContainment(SourceContainment row)
    {
        Containment containment = new(){
            Id = $"C{row.Id:D6}",
            TypeId = DataQuery.GetContainmentTypeId(row.ConType),
            Geometry = row.Geometry,
        };

        var building = row.SourceBuilding;

        if(building != null){
            containment.Location = building.ContLoc;
            containment.Size = building.Volume.HasValue ? (decimal?)building.Volume.Value : null;
            containment.PitDiameter = building.Dia.HasValue ? (decimal?)building.Dia.Value : null;
            containment.TankLength = building.Length.HasValue ? (decimal?)building.Length.Value : null;
            containment.TankWidth = building.Width.HasValue ? (decimal?)building.Width.Value : null;
            containment.Depth = building.Depth.HasValue ? (decimal?)building.Depth.Value : null;
            containment.SepticCriteria = building.Compliance?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true;
            // containment.ConstructionDate = building.Constr.HasValue ? Util.ConvertYearToDateTime(building.Constr.Value) : null;
            // containment.LastEmptiedDate = building.LastEmpDt?.Equals("Never Emptied", StringComparison.OrdinalIgnoreCase) == true ? null : Util.ConvertToDateTime(building.LastEmpDt);
            containment.ToiletCount = building.ToiletNum.HasValue ? (int?)building.ToiletNum.Value : null;
            containment.DistanceClosestWell = building.WellDis.HasValue ? (decimal?)building.WellDis.Value : null;
            containment.ResponsibleBin = building.Bin;
        }

        return containment;
    }

    public static Building BuildBuilding(SourceBuilding row) => new()
    {
        Bin = row.Bin ?? string.Empty,
        BuildingAssociatedTo = row.LinkMain.HasValue ? row.LinkMain.Value.ToString() : null,
        // Ward = row.Ward.HasValue ? (int?)row.Ward.Value : null,
        RoadCode = row.RoadUid,
        // HouseNumber = row.Holding,
        HouseLocality = row.Address,
        TaxCode = row.TaxMatch,
        StructureTypeId = DataQuery.GetStructureTypeId(row.StructType),
        FloorCount = row.Floor.HasValue ? (int?)row.Floor.Value : null,
        // ConstructionYear = row.ConstructionTime.HasValue ? Util.ConvertYearToDateTime(row.ConstructionTime.Value) : null,
        FunctionalUseId = DataQuery.GetFunctionalUseId(row.FuncUse),
        OfficeBusinessName = row.OfficeName,
        HouseholdServed = row.Household.HasValue ? (int?)row.Household.Value : null,
        PopulationServed = row.TotalPeople.HasValue ? (int?)row.TotalPeople.Value : null,
        MalePopulation = row.Male.HasValue ? (int?)row.Male.Value : null,
        FemalePopulation = row.Female.HasValue ? (int?)row.Female.Value : null,
        OtherPopulation = row.Others.HasValue ? (int?)row.Others.Value : null,
        DiffAbledMalePop = row.DisabledMale.HasValue ? (int?)row.DisabledMale.Value : null,
        DiffAbledFemalePop = row.DisabledFemale.HasValue ? (int?)row.DisabledFemale.Value : null,
        DiffAbledOthersPop = row.DisabledOthers.HasValue ? (int?)row.DisabledOthers.Value : null,
        LowIncomeHh = row.LowIncome?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        // LicId = row.LowIncomeName, // TODO: LicId is int, LowIncomeName is string
        WaterSourceId = DataQuery.GetWaterSourceId(row.WaterSource),
        WaterCustomerId = row.WaterId,
        WellPresenceStatus = row.Well?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        DistanceFromWell = row.WellDis.HasValue ? (decimal?)row.WellDis.Value : null,
        ToiletStatus = row.ToiletStatus?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        ToiletCount = row.ToiletNum.HasValue ? (int?)row.ToiletNum.Value : null,
        HouseholdWithPrivateToilet = row.ToiletHousehold.HasValue ? (int?)row.ToiletHousehold.Value : null,
        PopulationWithPrivateToilet = row.ToiletPopulation.HasValue ? (int?)row.ToiletPopulation.Value : null,
        DesludgingVehicleAccessible = row.Desludger?.Equals("Yes", StringComparison.OrdinalIgnoreCase) == true,
        Geometry = row.Geometry,
    };
}
