using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShapeFileData.TargetEntities
{
    [Table("users", Schema = "auth")]
    class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("username")]
        public required string Username { get; set; }

        [Column("email")]
        public required string Email { get; set; }
    }
}
