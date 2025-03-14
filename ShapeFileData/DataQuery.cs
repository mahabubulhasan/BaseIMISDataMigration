namespace ShapeFileData;

public static class DataQuery
{
    private static Dictionary<string, int>? _containmentTypeMap;
    private static Dictionary<string, int>? _structureTypeMap;
    private static Dictionary<string, int>? _functionalUseMap;
    private static Dictionary<string, int>? _waterSourceMap;
    private static Dictionary<string, int>? _lowIncomeCommunity;
    private static Dictionary<string, int>? _sanitationSystem;
    private static Dictionary<string, int>? _toiletMap;

    private static void initialize(string name)
    {
        using var context = new TargetDbContext();

        if (name == "ContainmentType" && _containmentTypeMap == null)
        {
            _containmentTypeMap = context.ContainmentTypes
                .ToDictionary(x => x.Type?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"{name} Initialized");
        }
        if (name == "StructureType" && _structureTypeMap == null)
        {
            _structureTypeMap = context.StructureTypes
                .ToDictionary(x => x.Type?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"{name} Initialized");
        }
        if (name == "FunctionalUse" && _functionalUseMap == null)
        {
            _functionalUseMap = context.FunctionalUses
                .ToDictionary(x => x.Name?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"{name} Initialized");
        }
        if (name == "WaterSource" && _waterSourceMap == null)
        {
            _waterSourceMap = context.WaterSources
                .ToDictionary(x => x.Source?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"{name} Initialized");
        }
        if (name == "LowIncomeCommunity" && _lowIncomeCommunity == null)
        {
            _lowIncomeCommunity = context.Lics
                .ToDictionary(x => x.CommunityName?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"{name} Initialized");
        }
        if (name == "SanitationSystem" && _sanitationSystem == null)
        {
            _sanitationSystem = context.SanitationSystems
                .ToDictionary(x => x.SanitationSystemName?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"{name} Initialized");
        }
        if (name == "Toilet" && _toiletMap == null)
        {
            _toiletMap = context.Toilets
                .ToDictionary(x => x.Name?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"{name} Initialized");
        }
    }

    public static int? GetContainmentTypeId(string? type)
    {
        initialize("ContainmentType");
        return string.IsNullOrEmpty(type) || _containmentTypeMap == null ? null :
            _containmentTypeMap.TryGetValue(type, out var id) ? id : null;
    }

    public static int? GetStructureTypeId(string? type)
    {
        initialize("StructureType");
        return string.IsNullOrEmpty(type) || _structureTypeMap == null ? null :
            _structureTypeMap.TryGetValue(type, out var id) ? id : null;
    }

    public static int? GetFunctionalUseId(string? name)
    {
        initialize("FunctionalUse");
        return string.IsNullOrEmpty(name) || _functionalUseMap == null ? null :
            _functionalUseMap.TryGetValue(name, out var id) ? id : null;
    }

    public static int? GetWaterSourceId(string? source)
    {
        initialize("WaterSource");
        return string.IsNullOrEmpty(source) || _waterSourceMap == null ? null :
            _waterSourceMap.TryGetValue(source, out var id) ? id : null;
    }

    public static int? GetLowIncomeCommunityId(string? name)
    {
        initialize("LowIncomeCommunity");
        return string.IsNullOrEmpty(name) || _lowIncomeCommunity == null ? null :
            _lowIncomeCommunity.TryGetValue(name, out var id) ? id : null;
    }

    public static int? GetSanitationSystemId(string? name)
    {
        initialize("SanitationSystem");
        return string.IsNullOrEmpty(name) || _sanitationSystem == null ? null :
            _sanitationSystem.TryGetValue(name, out var id) ? id : null;
    }

    public static int? GetToiletId(string? name)
    {
        initialize("Toilet");
        return string.IsNullOrEmpty(name) || _toiletMap == null ? null :
            _toiletMap.TryGetValue(name, out var id) ? id : null;
    }
}
