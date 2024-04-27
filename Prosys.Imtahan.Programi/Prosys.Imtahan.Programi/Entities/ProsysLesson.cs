using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prosys.Imtahan.Programi.Entities
{
    public class ProsysLesson
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }
        [Required]
        [MaxLength(30)]
        [Column(TypeName = "char(30)")]
        public string LessonName { get; set; }
        public int Classroom { get; set; }
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "char(20)")]
        public string TeacherFirstName { get; set; }
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "char(20)")]
        public string TeacherLastName { get; set; }
    }
}
