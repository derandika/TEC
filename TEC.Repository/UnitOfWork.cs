using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Repository.Interface;

namespace TEC.Repository
{
    /// <summary>
    /// UnitOfWork for EF operations
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TECContext _context;

        public UnitOfWork(TECContext context)
        {
            _context = context;
            CourseRepository = new CourseRepository(_context);
        }

        public ICourseRepository CourseRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
