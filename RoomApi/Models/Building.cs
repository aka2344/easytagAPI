using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RoomApi.Models
{
    public class Building:BaseEntity
    {
        [Key]
        public int BuildingNo { get; set; }
        public string BuildingName { get; set; }
        public int TotalFloor { get; set; }
    }
}
