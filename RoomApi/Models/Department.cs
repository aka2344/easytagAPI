using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RoomApi.Models
{
    public class Department:BaseEntity
    {
        [Key]
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public int DeptPhoneNum { get; set; }
    }
}
