using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prosys.Imtahan.Programi.Dtos
{
    public class StudentsResponse
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClassRoom { get; set; }
    }
}
