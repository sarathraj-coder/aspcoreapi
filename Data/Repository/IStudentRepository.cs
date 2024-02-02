using System;


namespace school.Data.Repository
{
    public interface IStudentRepository
    {
      public  Task<List<Student>> GetAllStudents();
       public   Task<Student> GetStudentById(int id);
       public   Task<Student> GetStudentByName(string name);
        public   Task<int> CreateStudent(Student student);
       public Task<int> UpdateStudent(Student student);
       public Task<bool> DeleteStudent(int id);

    }
}

