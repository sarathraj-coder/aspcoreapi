using System;
namespace school.MyLogging
{
	public class FileLogger :IMyLogger
	{
		

        void IMyLogger.Log(String message)
        {
            Console.WriteLine("FileLogger");
            Console.WriteLine(message);
        }
    }
}

