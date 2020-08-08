using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NabDeviceServices.Models
{
    public class DB_Info
    {
        public long Id { get; set; }
        public byte[] Version { get; set; }
        public byte[] AllowAdd { get; set; }
        public byte[] OldPeriod { get; set; }
        public byte[] NumberOfUser { get; set; }
    }
}
