using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NabDeviceServices.Models
{
    public class Define_Visitor
    {
        public long Id { get; set; }
        public string Nam { get; set; }
        public bool Activ { get; set; }
        public long Mon { get; set; }
        public byte[] Pas { get; set; }
    }
}
