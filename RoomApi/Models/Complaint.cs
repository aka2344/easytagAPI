using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RoomApi.Models
{
    public class Complaint:BaseEntity
    {
        [Key]
        public int RegistNo { get; set; }
        public string Request { get; set; }
        public DateTime RegistDate { get; set; }
        public DateTime FixedDate { get; set; }
        public double EquipNo { get; set; }
        public string UserID { get; set; }
    }
}
