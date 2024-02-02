using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school.Data;
using school.Data.Repository;
using school.Model;
namespace school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _iMapper;
		public StudentController(IStudentRepository studentRepository, IMapper iMapper)
		{
            this._studentRepository = studentRepository;
            this._iMapper = iMapper;
		}

        [HttpGet]
        public String GetStudentName()
        {
            return "Sarath Raj";
        }

        [HttpGet]
        [Route("All",Name ="GetAllStudents")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Student>))]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            var Students = await _studentRepository.GetAllStudents();
            var studentDtoData = _iMapper.Map<IEnumerable<StudentDTO>>(Students);

        //    var Students =  _collegeDBContext.Students.Select(n => new StudentDTO()
        //     {

        //         Id = n.Id,
        //         Name = n.Name,
        //         Address = n.Address,
        //         Email = n.Email,
        //         Dob = n.Dob.ToString("yyyy-MM-dd")

        //     });
            return Ok(studentDtoData);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            if (id <= 0) return BadRequest();
            var student = await _studentRepository.GetStudentById(id);
            if(student == null) return NotFound();
            // return Ok(new StudentDTO() {
            //     Id = student.Id,
            //     Name = student.Name,
            //     Address = student.Address,
            //     Email = student.Email
            // });
            return Ok(_iMapper.Map<StudentDTO>(student));

        }

        [HttpGet("{name}", Name = "GetStudentByName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StudentDTO>> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return  BadRequest();
            var student = await _studentRepository.GetStudentByName(name);
            if (student == null) return NotFound();
           
            return Ok(_iMapper.Map<StudentDTO>(student));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async  Task<ActionResult<Boolean>> DeleteStudentById(int id)
        {
            if (id <= 0) return BadRequest();
            var status = await _studentRepository.DeleteStudent(id);
            return Ok(status);
        }


        [HttpPost]
        [Route("create", Name = "CreateStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async  Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO studentDto)
        {
            if (studentDto == null) return BadRequest();
            //var studentId = _collegeDBContext.Students.LastOrDefault().Id + 1;
            //   var student  =new Student()
            //     {
            //         Name = studentDto.Name,
            //         Address = studentDto.Address,
            //         Email = studentDto.Email,
            //         Dob= Convert.ToDateTime(studentDto.Dob)
            //     };
            var student = _iMapper.Map<StudentDTO, Student>(studentDto);
              var studentReturnedId =  await  _studentRepository.CreateStudent(student);
             studentDto.Id = studentReturnedId;
            //_collegeDBContext.SaveChanges();
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
              var student = _iMapper.Map<StudentDTO, Student>(studentDto);
             var studentId = _studentRepository.UpdateStudent(student);
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
        public async Task<ActionResult<StudentDTO>> UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<StudentDTO> patchDocument)
        {
            if (patchDocument == null || id<=0) return BadRequest();
            //var student = _collegeDBContext.Students.Where(i => i.Id == id).FirstOrDefault();
             var student = await _studentRepository.GetStudentById(id);
            if (student == null) return NotFound();

            // var studentDto= new StudentDTO()
            // {
            //     Id = student.Id,
            //     Name = student.Name,
            //     Address = student.Address,
            //     Email = student.Email
            // };
            var studentDto = _iMapper.Map<StudentDTO>(student);

            patchDocument.ApplyTo(studentDto, ModelState);
            if(!ModelState.IsValid)
                return BadRequest();

            // student.Name = studentDto.Name;
            // student.Address = studentDto.Address;
            // student.Email = studentDto.Email;
            // _studentRepository.SaveChanges();
            var result =  await _studentRepository.UpdateStudent(student);
            return NoContent();
            // return Ok(studentDto);
        }
    }
}


