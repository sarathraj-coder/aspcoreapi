using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace school.Data.Repository
{
    public class CollegeRepository<T> : ICollegeRepository<T> where T : class
    {
         private readonly CollegeDBContext _collegeDBContext;
         private DbSet<T> _dbSet;
        
        public CollegeRepository(CollegeDBContext collegeDBContext)
        {
            _collegeDBContext = collegeDBContext;
            _dbSet = _collegeDBContext.Set<T>();
        }

        public async Task<T> CreateAsync(T dbRecord)
        {
            _dbSet.Add(dbRecord);
            await _collegeDBContext.SaveChangesAsync();
            return dbRecord;
        }

        

        public async Task<bool> Delete(T dbRecord)
        {
                _dbSet.Remove(dbRecord);
                await _collegeDBContext.SaveChangesAsync();
                return true;
            
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
        {
            var record = await _dbSet.Where(predicate).FirstOrDefaultAsync();
            return record;
        }

       

        public async Task<T> GetByNameAsync(Expression<Func<T, bool>> predicate)
        {
           var record = await _dbSet.Where(predicate).FirstOrDefaultAsync();
            return record;
        }

        

        public async Task<T> UpdateAsync(T dbRecord)
        {
            _dbSet.Update(dbRecord);
            await _collegeDBContext.SaveChangesAsync();
            return dbRecord;
        }
    }
}
