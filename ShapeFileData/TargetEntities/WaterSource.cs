using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.TargetEntities;

[Table("water_sources", Schema = "building_info")]
public class WaterSource
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("source")]
    [StringLength(255)]
    public required string Source { get; set; }
}
