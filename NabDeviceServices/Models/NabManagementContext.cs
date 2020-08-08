using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NabDeviceServices.Models
{
    public class NabManagementContext : DbContext
    {
        public NabManagementContext(DbContextOptions<NabManagementContext> options)
        : base(options)
        {
        }

        public DbSet<List_Accounting> List_Accounting { get; set; }
        public DbSet<List_Period> List_Period { get; set; }
    }
}
