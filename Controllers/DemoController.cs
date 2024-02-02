using System;
using Microsoft.AspNetCore.Mvc;
using school.MyLogging;

namespace school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController  : ControllerBase
	{
        private readonly IMyLogger _myLogger;

        //Loosely couped technique
        public DemoController(IMyLogger myLogger)
		{
            _myLogger = myLogger;

        }

        [HttpGet]
        public String GetStudentName()
        {
            _myLogger.Log("Testing");
            return "Sarath Raj";
        }
    }
}

