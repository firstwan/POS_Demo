using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace POS_Demo.Domain.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly AppDBContext _context;
        protected IQueryable<T> _queryBuilder;

        public BaseRepository(AppDBContext DBcontext)
        {
            _context = DBcontext;
            _queryBuilder = _context.Set<T>();
        }

        protected async Task<IEnumerable<T>> ReturnAllResult()
        {
            return await _queryBuilder.ToListAsync();
        }

        protected async Task<T> ReturnSingleRerult()
        {
            return await _queryBuilder.FirstOrDefaultAsync();
        }

        protected void ResetQueryBuilder()
        {
            _queryBuilder = _context.Set<T>();
        }

        public T Update(T Obj)
        {
            _context.Set<T>().Update(Obj);

            return Obj;
        }

        public async Task<T> Create(T Obj)
        {
            await _context.Set<T>().AddAsync(Obj);

            return Obj;
        }

        public void Delete(T Obj)
        {
            _context.Set<T>().Remove(Obj);
        }

        public async Task DBCommit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
