using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.TargetEntities;

[Table("use_categorys", Schema = "building_info")]
public class UseCategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("functional_use_id")]
    public int? FunctionalUseId { get; set; }
}
