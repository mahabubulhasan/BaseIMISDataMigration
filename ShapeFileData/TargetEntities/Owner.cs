using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.TargetEntities;

[Table("owners", Schema = "building_info")]
public class Owner
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("bin")]
    public string? Bin { get; set; }

    [Column("owner_name")]
    public string? OwnerName { get; set; }

    [Column("owner_gender")]
    public string? OwnerGender { get; set; }

    [Column("owner_contact")]
    public long? OwnerContact { get; set; }

    [Column("nid")]
    public string? Nid { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}
