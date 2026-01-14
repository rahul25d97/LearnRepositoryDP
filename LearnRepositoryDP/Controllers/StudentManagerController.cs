using LearnRepositoryDP.Interface;
using LearnRepositoryDP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Formatting = Newtonsoft.Json.Formatting;

namespace LearnRepositoryDP.Controllers
{
    [ApiController]
    public class StudentManagerController : ControllerBase
    {
        private readonly IStudentManager _IStudentManager;
        private readonly ILogger<StudentManagerController> _logger;

        public StudentManagerController(ILogger<StudentManagerController> logger, IStudentManager IStudentManager)
        {
            _logger = logger;
            _IStudentManager = IStudentManager;
        }

        [HttpGet]
        [Route("api/[controller]/Get_AllStudents")]
        public IActionResult Get_AllStudents()
        {
            try
            {
                DataTable dt = _IStudentManager.Get_AllStudents();

                return Ok(JsonConvert.SerializeObject(dt, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/[controller]/Get_StudentById")]
        public IActionResult Get_StudentById(int StudentId)
        {
            try
            {
                DataTable dt = _IStudentManager.Get_StudentById(StudentId);

                return Ok(JsonConvert.SerializeObject(dt, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/[controller]/Save_Student")]
        public IActionResult Save_Student(Student obj)
        {
            try
            {
                DataTable dt = _IStudentManager.Save_Student(obj);
                return Ok(JsonConvert.SerializeObject(dt, Formatting.Indented));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
