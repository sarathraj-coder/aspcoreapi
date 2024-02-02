using System;
using System.Linq.Expressions;


namespace school.Data.Repository
{
    public interface ICollegeRepository<T>
    {
      public  Task<List<T>> GetAllAsync();
       public   Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);
       public   Task<T> GetByNameAsync(Expression<Func<T, bool>> predicate);
        public   Task<T> CreateAsync(T dbRecord);
       public Task<T> UpdateAsync(T dbRecord);
       public Task<bool> Delete(T record);

    }
}

