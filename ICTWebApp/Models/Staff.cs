using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ICTWebApp.Models
{
    public class Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }
        [Display(Name = "ชื่อเจ้าหน้าที่")]
        [Required(ErrorMessage = "กรุณากรอกชื่อเจ้าหน้าที่")]
        public string StaffName { get; set; }
    }
}
