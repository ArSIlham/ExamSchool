using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prosys.Imtahan.Programi.Common;
using Prosys.Imtahan.Programi.Database;
using Prosys.Imtahan.Programi.Dtos;
using Prosys.Imtahan.Programi.Entities;

namespace Prosys.Imtahan.Programi.Controllers
{
    [ApiController]
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public LessonController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("add-lesson")]
        public async Task<IActionResult> Add(ProsysLesson lesson)
        {
            await _dbContext.ProsysLesson.AddAsync(new ProsysLesson
            {
                Classroom = lesson.Classroom,
                LessonCode = lesson.LessonCode,
                LessonName = lesson.LessonName,
                TeacherFirstName = lesson.TeacherFirstName,
                TeacherLastName = lesson.TeacherLastName,
            });
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpPost("edit-lesson")]
        public async Task<IActionResult> Edit(ProsysLesson lessonid)
        {

            _dbContext.ProsysLesson.Update(lessonid);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("delete-lesson")]
        public async Task<IActionResult> Delete(int lessonid)
        {
            var examp = await _dbContext.ProsysLesson.Where(x => x.Id == lessonid).FirstOrDefaultAsync();
            _dbContext.ProsysLesson.Remove(examp);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("byid-lesson")]
        public async Task<IActionResult> GetbyId(int lessonid)
        {
            var data = await _dbContext.ProsysLesson.Where(x => x.Id == lessonid).FirstOrDefaultAsync();
            return Ok(data);
        }
        [HttpGet("get-all-lesson")]
        public async Task<IActionResult> GetAlllesson()
        {
            var data = _dbContext.ProsysLesson.AsEnumerable();

            var Lesson = data.Select(c => new LessonResponse
            {
                Classroom = c.Classroom,
                LessonCode = c.LessonCode,
                LessonName = c.LessonName,
                TeacherFirstName = c.TeacherFirstName,
                TeacherLastName = c.TeacherLastName,
                Id = c.Id,
            }
                );

            return Ok(new ApiResponse<IEnumerable<LessonResponse>>(Lesson));
        }
    }
}
