using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prosys.Imtahan.Programi.Entities
{
    public class ProsysStudents
    {
        public int Id { get; set; }

        public int Number { get; set; }
        [Required]
        [MaxLength(30)]
        [Column(TypeName = "char(30)")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        [Column(TypeName = "char(30)")]
        public string LastName { get; set; }
        public int ClassRoom { get; set; }
    }
}
