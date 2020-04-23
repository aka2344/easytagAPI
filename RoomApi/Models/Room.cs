using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RoomApi.Models
{
    public class Room:BaseEntity
    {
        [Key]
        public int Roomid { get; set; }

        public string Roomname { get; set; }

        public double Area { get; set; }
        public string Roomnum { get; set; }
        public int BuildingNo { get; set; }
        public int DeptNo { get; set; }
        public int Floor { get; set; }

    }
}
