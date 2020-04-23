using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RoomApi.Models
{
    public class Maintenance:BaseEntity
    {
        [Key]
        public int M_No { get; set; }
        public DateTime ApplyDate { get; set; }
        public string ApplyReason { get; set; }
        public bool IsApproval { get; set;}
        public DateTime ApprovalDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Details { get; set; }
        public int Cost { get; set; }
        public double EquipNo { get; set; }
    }
}
