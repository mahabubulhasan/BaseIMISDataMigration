using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.TargetEntities;

[Table("containment_types", Schema = "fsm")]
public class ContainmentType
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("type")]
    [StringLength(100)]
    public required string Type { get; set; }

    [Column("sanitation_system_id")]
    [ForeignKey("SanitationSystem")]
    public int? SanitationSystemId { get; set; }

    [Column("dashboard_display")]
    public bool? DashboardDisplay { get; set; }

    [Column("map_display")]
    [StringLength(100)]
    public string? MapDisplay { get; set; }
}
