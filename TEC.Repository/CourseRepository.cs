using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Domain.Models;
using TEC.Repository.Interface;

namespace TEC.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(TECContext context)
            : base(context)
        {
        }

        public TECContext TECContext
        {
            get { return Context as TECContext; }
        }
    }
}
