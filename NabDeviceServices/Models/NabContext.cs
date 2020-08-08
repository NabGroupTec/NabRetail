using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NabDeviceServices.Models;

namespace NabDeviceServices.Models
{
    public class NabContext : DbContext
    {
        public NabContext(DbContextOptions<NabContext> options)
            : base(options)
        {
        }

        public DbSet<Define_User> Define_User { get; set; }
        public DbSet<Define_Visitor> Define_Visitor { get; set; }
        public DbSet<DB_Info> Db_Info { get; set; }
        public DbSet<Define_People> Define_People { get; set; }
        public DbSet<Define_Kala> DefineKala { get; set; }
        public DbSet<Mobile_NewPeople> Mobile_NewPeople { get; set; }
        public DbSet<NabDeviceServices.Models.Mobile_ListFactorSell> Mobile_ListFactorSell { get; set; }
        public DbSet<NabDeviceServices.Models.Mobile_KalaFactorSell> Mobile_KalaFactorSell { get; set; }
    }
}
