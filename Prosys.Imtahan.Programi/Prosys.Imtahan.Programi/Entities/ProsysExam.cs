using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prosys.Imtahan.Programi.Entities
{
    public class ProsysExam
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }
        [Required]
        public int StudentNumber { get; set; }
        [Required]
        public DateTime ExamDate { get; set; } = DateTime.Now;
        [Required]
        public int Score { get; set; }
    }
}
