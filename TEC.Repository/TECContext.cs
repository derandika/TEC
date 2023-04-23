using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Domain.Models;

namespace TEC.Repository
{
    /// <summary>
    /// TEC DbContext
    /// </summary>
    public class TECContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }

        public TECContext(DbContextOptions<TECContext> options)
            : base(options)
        {

        }
    }
}
