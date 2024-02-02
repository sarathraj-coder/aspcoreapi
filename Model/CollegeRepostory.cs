using System;
namespace school.Model
{
	public  static class CollegeRepostory
	{
		public static List<Student> Students { get; set; } = new List<Student> { new Student {
                Id = 1,
                Name = "Sarath",
                Address = "doha",
                Email = "sarathraj2008@gmail.com"

            },
               new Student {
                    Id = 2,
                Name = "sam",
                Address = "doha",
                Email = "sam@gmail.com"

            }};
    }
}

