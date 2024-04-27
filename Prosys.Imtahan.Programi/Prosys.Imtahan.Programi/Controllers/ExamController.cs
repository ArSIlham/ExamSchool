using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prosys.Imtahan.Programi.Common;
using Prosys.Imtahan.Programi.Database;
using Prosys.Imtahan.Programi.Dtos;
using Prosys.Imtahan.Programi.Entities;
using System.Net;

namespace Prosys.Imtahan.Programi.Controllers
{
    [ApiController]
    public class ExamController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ExamController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("add-exam")]
        public async Task<IActionResult> Add(Programi.Dtos.ExamResponse exam)
        {
           var students =  _dbContext.ProsysStudents.Where(x => x.Number == exam.StudentNumber).FirstOrDefault();
            var lesson = _dbContext.ProsysLesson.Where(x => x.LessonCode == exam.LessonCode).FirstOrDefault();
            if (students == null )
            {
                return Ok(new ApiException("Üzür İstəyirik Telebe Əlavə Etmədən İmtahan Əlavə Edə Bilməsiniz", HttpStatusCode.BadRequest));


                

            }
            if (lesson == null)
            {
                return Ok(new ApiException("Üzür İstəyirik Dərs Əlavə Etmədən İmtahan Əlavə Edə Bilməsiniz", HttpStatusCode.BadRequest));

            }
            else
            {
                await _dbContext.ProsysExam.AddAsync(new ProsysExam
                {
                    ExamDate = exam.ExamDate,
                    LessonCode = exam.LessonCode,
                    Score = exam.Score,
                    StudentNumber = exam.StudentNumber,
                });
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpGet("edit-exam")]
        public async Task<IActionResult> Edit(ProsysExam examid)
        {

             _dbContext.ProsysExam.Update(examid);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("delete-exam")]
        public async Task<IActionResult> Delete(int examid)
        {
            var examp = await _dbContext.ProsysExam.Where(x => x.Id == examid).FirstOrDefaultAsync();
            _dbContext.ProsysExam.Remove(examp);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("byid-exam")]
        public async Task<IActionResult> GetbyId(int examid)
        {
            var data = await _dbContext.ProsysExam.Where(x=>x.Id == examid).FirstOrDefaultAsync();
            return Ok(data);
        }
        [HttpGet("get-all-exam")]
        public async Task<IActionResult> GetAllExam()
        {
            var data =  _dbContext.ProsysExam.AsEnumerable();
            var Exam = data.Select(c => new ExamResponse{
                 ExamDate = c.ExamDate,
                  LessonCode = c.LessonCode,
                   Score = c.Score,
                    StudentNumber = c.StudentNumber,
                     Id = c.Id,
            });


            return Ok(new ApiResponse<IEnumerable<ExamResponse>>(Exam));
        }
    }
}
