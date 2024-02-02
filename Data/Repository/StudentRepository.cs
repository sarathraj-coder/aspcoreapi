using System;
using Microsoft.EntityFrameworkCore;

namespace school.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeDBContext _collegeDBContext;

        
        public StudentRepository(CollegeDBContext collegeDBContext)
        {
            _collegeDBContext = collegeDBContext;
        }
        public async Task<int> CreateStudent(Student student)
        {
            _collegeDBContext.Students.Add(student);
            await _collegeDBContext.SaveChangesAsync();
            return student.Id;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var studentToUpdate = await _collegeDBContext.Students.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (studentToUpdate == null)
            {
                throw new Exception("Student not found");
            }
            if (studentToUpdate != null)
            {
                _collegeDBContext.Students.Remove(studentToUpdate);
                _collegeDBContext.SaveChanges();
            }
            return true;

        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _collegeDBContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _collegeDBContext.Students.Where(i => i.Id == id).FirstOrDefaultAsync();
            return student;
        }

        public async Task<Student> GetStudentByName(string name)
        {
            var student = await _collegeDBContext.Students.Where(i => i.Name == name).FirstOrDefaultAsync();
            return student;
        }

        public async Task<int> UpdateStudent(Student student)
        {
            var studentToUpdate = await _collegeDBContext.Students.Where(i => i.Id == student.Id).FirstOrDefaultAsync();
            if (studentToUpdate == null)
            {
                throw new Exception("Student not found");
            }
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = student.Name;
                studentToUpdate.Address = student.Address;
                studentToUpdate.Email = student.Email;
                studentToUpdate.Dob = student.Dob;
                await _collegeDBContext.SaveChangesAsync();
            }
            return studentToUpdate.Id;
        }
    }
}