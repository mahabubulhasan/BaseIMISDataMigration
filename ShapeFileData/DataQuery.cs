namespace ShapeFileData;

public static class DataQuery
{
    private static readonly Dictionary<string, int> _containmentTypeMap;
    private static readonly Dictionary<string, int> _structureTypeMap;
    private static readonly Dictionary<string, int> _functionalUseMap;
    private static readonly Dictionary<string, int> _waterSourceMap;
    private static readonly Dictionary<string, int> _lowIncomeCommunity;
    private static readonly Dictionary<string, int> _sanitationSystem;

    static DataQuery()
    {
        using var context = new TargetDbContext();

        _containmentTypeMap = context.ContainmentTypes
            .ToDictionary(x => x.Type?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);

        _structureTypeMap = context.StructureTypes
            .ToDictionary(x => x.Type?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);

        _functionalUseMap = context.FunctionalUses
            .ToDictionary(x => x.Name?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);

        _waterSourceMap = context.WaterSources
            .ToDictionary(x => x.Source?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);

        _lowIncomeCommunity = context.Lics
            .ToDictionary(x => x.CommunityName?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);

        _sanitationSystem = context.SanitationSystems
            .ToDictionary(x => x.SanitationSystemName?.ToLowerInvariant() ?? string.Empty, x => x.Id, StringComparer.OrdinalIgnoreCase);

        Console.WriteLine("DataQuery Initialized");
    }

    public static int? GetContainmentTypeId(string? type) =>
        string.IsNullOrEmpty(type) ? null :
            _containmentTypeMap.TryGetValue(type, out var id) ? id : null;

    public static int? GetStructureTypeId(string? type) =>
        string.IsNullOrEmpty(type) ? null :
            _structureTypeMap.TryGetValue(type, out var id) ? id : null;

    public static int? GetFunctionalUseId(string? name) =>
        string.IsNullOrEmpty(name) ? null :
            _functionalUseMap.TryGetValue(name, out var id) ? id : null;

    public static int? GetWaterSourceId(string? source) =>
        string.IsNullOrEmpty(source) ? null :
            _waterSourceMap.TryGetValue(source, out var id) ? id : null;

    public static int? GetLowIncomeCommunityId(string? name) =>
        string.IsNullOrEmpty(name) ? null :
            _lowIncomeCommunity.TryGetValue(name, out var id) ? id : null;

    public static int? GetSanitationSystemId(string? name) =>
        string.IsNullOrEmpty(name) ? null :
            _sanitationSystem.TryGetValue(name, out var id) ? id : null;
}
