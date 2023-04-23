using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC.Repository.Interface
{
    /// <summary>
    /// UnitOfWork Interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository CourseRepository { get; }
        int Complete();
    }
}
