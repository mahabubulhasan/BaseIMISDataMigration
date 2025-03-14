> Change the Database Connection string in `appsettings.json` file.

## Check inserted data
```sql
select * from fsm.containment_types ct ;
select * from building_info.structure_types st;
select * from building_info.functional_uses fu ;
select * from building_info.water_sources ws ;

select * from utility_info.roads r ;
select * from utility_info.drains d ;

select * from layer_info.wards w ;
select * from layer_info.wardboundary w ;

select * from building_info.buildings b ;
select * from building_info.owners o ;
select * from fsm.containments c ;
select * from layer_info.low_income_communities lic ;
select * from fsm.treatment_plants tp ;
select * from fsm.toilets t ;
```

## Clean all the inserted data
```sql
truncate table fsm.containment_types cascade;
truncate table building_info.structure_types cascade;
truncate table building_info.functional_uses cascade;
truncate table building_info.water_sources cascade;
truncate table utility_info.roads cascade;
truncate table utility_info.drains cascade;
truncate table layer_info.wards cascade;
truncate table layer_info.wardboundary cascade;
truncate table building_info.buildings cascade;
truncate table building_info.owners cascade;
truncate table fsm.containments cascade;
truncate table layer_info.low_income_communities cascade;
truncate table fsm.treatment_plants cascade;
truncate table fsm.toilets cascade;
truncate table fsm.build_toilets cascade;
```

## Check for duplicates
```sql
select wb."Ward_No", count(wb."Ward_No") as total from "Ward_boundary" wb group by wb."Ward_No" order by total desc;

select b."BIN", count(b."BIN") as total from "Buildings" b group by b."BIN" order by total desc;
```

```csharp
// Calling Order is important
AddRows<SourceRoad, Road>(EntityBuilder.BuildRoad, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourceDrain, Drain>(EntityBuilder.BuildDrain, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourceWard, Ward>(EntityBuilder.BuildWard, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourceWard, WardBoundary>(EntityBuilder.BuildWardBoundary, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourceBuilding, Building>(EntityBuilder.BuildBuilding, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourceBuilding, Owner>(EntityBuilder.BuildOwner, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourceContainment, Containment>(EntityBuilder.BuildContainment, (source, skip, batchSize) => [.. source.Include(x => x.SourceBuilding).Skip(skip).Take(batchSize)]);
AddRows<SourceLic, Lic>(EntityBuilder.BuildLic, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourceTreatmentPlant, TreatmentPlant>(EntityBuilder.BuildTreatmentPlant, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourceCommunityToilet, Toilet>(EntityBuilder.BuildToilet, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
AddRows<SourcePublicToilet, Toilet>(EntityBuilder.BuildToilet, (source, skip, batchSize) => [.. source.Skip(skip).Take(batchSize)]);
```