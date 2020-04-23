using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RoomApi.Models
{
    public class Survey:BaseEntity
    {
        [Key]
        public int SurveyNo { get; set; }
        public DateTime SurveyDate { get; set; }
        public string SurveyResult { get; set; }
        public string ETC { get; set; }
        public int EquipNo { get; set; }
    }
}
