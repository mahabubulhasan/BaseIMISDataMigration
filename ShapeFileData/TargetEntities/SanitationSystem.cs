using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.TargetEntities
{
    [Table("sanitation_systems", Schema = "building_info")]
    public class SanitationSystem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("sanitation_system")]
        [StringLength(100)]
        public string? SanitationSystemName { get; set; }

        [Column("dashboard_display")]
        public bool? DashboardDisplay { get; set; }

        [Column("map_display")]
        public bool? MapDisplay { get; set; }

        [Column("icon_name")]
        [StringLength(255)]
        public string? IconName { get; set; }
    }
}
