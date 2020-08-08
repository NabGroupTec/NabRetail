using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NabDeviceServices.Models
{
    public class Mobile_ListFactorSell
    {
        [Key]
        public long IdFactor { get; set; }
        public string D_date { get; set; }
        public string T_time { get; set; }
        public long? IdName { get; set; }
        public long? IdVisitor { get; set; }
        public long? IdUser { get; set; }
        public int Confirm { get; set; }
        public int? Rate { get; set; }
        public int Kind { get; set; }
        public string Disc { get; set; }
        public long? IdSell { get; set; }
        public long? IdNewPeople { get; set; }
        public long? IdAnbar { get; set; }
    }
}
