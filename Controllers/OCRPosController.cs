using System;
using System.Net;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using school.Model;

namespace school.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OCRPosController : ControllerBase
	{
		public OCRPosController()
		{
		}

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return CollegeRepostory.Students;
        }


    }
}

