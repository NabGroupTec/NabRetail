using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabDeviceServices.Models
{
    public class Mobile_KalaFactorSell
    {
        [Key]
        public long ID { get; set; }
        public long IdFactor { get; set; }
        public long IdKala { get; set; }
        public double KolCount { get; set; }
        public double JozCount { get; set; }
        public double Discount { get; set; }
        public long Fe { get; set; }
        public long OldFe { get; set; }
        public long IdAnbar { get; set; }
    }
}
