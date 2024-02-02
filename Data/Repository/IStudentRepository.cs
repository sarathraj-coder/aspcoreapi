using System;


namespace school.Data.Repository
{
    public interface IStudentRepository : ICollegeRepository<Student>
    {
    
     List<Student> GetAllStudentsByFeesStatus( int feesStatus);

    }
}

