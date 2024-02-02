using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using school.Model;

namespace school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
		public StudentController()
		{
		}

        [HttpGet]
        public String GetStudentName()
        {
            return "Sarath Raj";
        }

        [HttpGet]
        [Route("All",Name ="GetAllStudents")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Student>))]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
           var Students =  CollegeRepostory.Students.Select(n => new StudentDTO()
            {

                Id = n.Id,
                Name = n.Name,
                Address = n.Address,
                Email = n.Email

            });
            return Ok(Students);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            if (id <= 0) return BadRequest();
            var student = CollegeRepostory.Students.Where(i => i.Id == id).FirstOrDefault();
            if(student == null) return NotFound();
            return Ok(new StudentDTO() {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Email = student.Email
            });
        }

        [HttpGet("{name}", Name = "GetStudentByName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<StudentDTO> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest();
            var student = CollegeRepostory.Students.Where(i => i.Name == name).FirstOrDefault();
            if (student == null) return NotFound();
            return Ok(new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Email = student.Email
            });
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Boolean> DeleteStudentById(int id)
        {
            if (id <= 0) return BadRequest();
            var student =  CollegeRepostory.Students.Where(i => i.Id == id).FirstOrDefault();
            if (student == null) return NotFound();
            CollegeRepostory.Students.Remove(student);
            return Ok(true);
        }


        [HttpPost]
        [Route("create", Name = "CreateStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO studentDto)
        {
            if (studentDto == null) return BadRequest();
            var studentId = CollegeRepostory.Students.LastOrDefault().Id + 1;
   
                CollegeRepostory.Students.Add(new Student()
                {
                    Id = studentId,
                    Name = studentDto.Name,
                    Address = studentDto.Address,
                    Email = studentDto.Email
                });
            studentDto.Id = studentId;
            return CreatedAtRoute("GetStudentById", new { id = studentDto .Id }, studentDto);
           // return Ok(studentDto);

          
           
        }


        [HttpPut]  // send all fields to server 
        [Route("update", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<StudentDTO> UpdateStudent([FromBody] StudentDTO studentDto)
        {
            if (studentDto == null) return BadRequest();
            var student = CollegeRepostory.Students.Where(i => i.Id == studentDto.Id).FirstOrDefault();
            if (student == null) return NotFound();

            student.Name = studentDto.Name;
            student.Address = studentDto.Address;
            student.Email = studentDto.Email;
    
            return NoContent();
            // return Ok(studentDto);
        }

        //json patch library
        //dotnet add package Microsoft.AspNetCore.JsonPatch --version 8.0.1
        //dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 8.0.1
        //jsonpatch.com to learn some pattern
        [HttpPatch]  // send all fields to server 
        [Route("{id:int}/updatePartial", Name = "UpdateStudentPartial")]
        //api/student/1/updatePartial
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<StudentDTO> UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<StudentDTO> patchDocument)
        {
            if (patchDocument == null || id<=0) return BadRequest();
            var student = CollegeRepostory.Students.Where(i => i.Id == id).FirstOrDefault();
            if (student == null) return NotFound();

            var studentDto= new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Email = student.Email
            };

            patchDocument.ApplyTo(studentDto, ModelState);
            if(!ModelState.IsValid)
                return BadRequest();

            student.Name = studentDto.Name;
            student.Address = studentDto.Address;
            student.Email = studentDto.Email;

            return NoContent();
            // return Ok(studentDto);
        }
    }
}


