using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.TargetEntities
{
    [Table("build_toilets", Schema = "fsm")]
    public class BuildToilet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("bin")]
        [StringLength(255)]
        public string? Bin { get; set; }

        [Column("toilet_id")]
        public int? ToiletId { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [InverseProperty("BuildToilet")]
        [ForeignKey("Bin")]
        public virtual Building? Building { get; set; }
    }
}
