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
```

## Check for duplicates
```sql
select wb."Ward_No", count(wb."Ward_No") as total from "Ward_boundary" wb group by wb."Ward_No" order by total desc;

select b."BIN", count(b."BIN") as total from "Buildings" b group by b."BIN" order by total desc;
```