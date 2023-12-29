using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.Data
{
    public class StudentPortalContext : DbContext
    {
        public StudentPortalContext (DbContextOptions<StudentPortalContext> options)
            : base(options)
        {
        }

        public DbSet<StudentPortal.Models.Students> Students { get; set; } = default!;
    }
}
