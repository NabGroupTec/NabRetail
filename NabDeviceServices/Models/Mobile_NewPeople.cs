using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabDeviceServices.Models
{
    public class Mobile_NewPeople
    {
        public long Id { get; set; }
        public string Nam { get; set; }
        public string Tell1 { get; set; }
        public string Tell2 { get; set; }
        public string Adres { get; set; }
        public string D_date { get; set; }
        public string T_time { get; set; }
        public long IdGroup { get; set; }
        public long IdOstan { get; set; }
        public long IdCity { get; set; }
        public long IdPart { get; set; }
        public long IdVisitor { get; set; }
        public long IdUser { get; set; }
    }
}
