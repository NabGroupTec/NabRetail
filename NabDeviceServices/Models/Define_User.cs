using System.ComponentModel.DataAnnotations;

namespace NabDeviceServices.Models
{
    public class Define_User
    {
        [Key]
        public long Id { get; set; }
        public string Nam { get; set; }
        public int TypeImage { get; set; }
        public byte[] Image { get; set; }
        public byte[] Pas { get; set; }
        public byte[] UserLogIn { get; set; }
    }
}
