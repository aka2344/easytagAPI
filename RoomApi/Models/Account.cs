using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RoomApi.Models
{
    public class Account : BaseEntity
    {
        [Key]
        public string UserID { get; set; }
        public string UserPW { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Authority { get; set; }
        public int DeptNo { get; set; }
    }

}
