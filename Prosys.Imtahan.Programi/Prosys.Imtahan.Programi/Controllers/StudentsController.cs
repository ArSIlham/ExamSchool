using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prosys.Imtahan.Programi.Common;
using Prosys.Imtahan.Programi.Database;
using Prosys.Imtahan.Programi.Dtos;
using Prosys.Imtahan.Programi.Entities;

namespace Prosys.Imtahan.Programi.Controllers
{

    [ApiController]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("add-students")]
        public async Task<IActionResult> Add(ProsysStudents students)
        {
            await _dbContext.ProsysStudents.AddAsync(new ProsysStudents
            {
                ClassRoom = students.ClassRoom,
                FirstName = students.FirstName,
                LastName = students.LastName,
                Number = students.Number,
            });
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpPost("edit-students")]
        public async Task<IActionResult> Edit(ProsysStudents student)
        {

            _dbContext.ProsysStudents.Update(student);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("delete-students")]
        public async Task<IActionResult> Delete(int studentid)
        {
            var examp = await _dbContext.ProsysStudents.Where(x => x.Id == studentid).FirstOrDefaultAsync();
            _dbContext.ProsysStudents.Remove(examp);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("byid-students")]
        public async Task<IActionResult> GetbyId(int studentid)
        {
            var data = await _dbContext.ProsysStudents.Where(x => x.Id == studentid).FirstOrDefaultAsync();
            return Ok(data);
        }
        [HttpGet("get-all-students")]
        public async Task<IActionResult> GetAllExam()
        {
            var data = _dbContext.ProsysStudents.AsEnumerable();

            var Student = data.Select(c => new StudentsResponse
            {
                Id = c.Id,
                ClassRoom = c.ClassRoom,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Number = c.Number
            });

            return Ok(new ApiResponse<IEnumerable<StudentsResponse>>(Student));
        }
    }
}
