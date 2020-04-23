using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RoomApi.Models
{
    public class History:BaseEntity
    {
        [Key]
        public int HistoryNo { get; set; }
        public double EquipNo { get; set; }
        public int CauseNo { get; set; }
        public string Name_KR { get; set; }
        public string Name_ENG { get; set; }
        public string ItemName { get; set; }
        public bool IsDisuse { get; set; }
        public DateTime InDate { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public int LifeYear { get; set; }
        public string Status { get; set; }
        public DateTime QR_Date { get; set; }
        public string ETC { get; set; }
        public int RoomID { get; set; }
        public string UserID { get; set; }
        public string AdminID { get; set; }
        public DateTime EditDate { get; set; }
        public string EditType { get; set; }
    }
}
