using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ICTWebApp.Models
{
    //Mapping to Table
    //[Table("category")]
    public class Category
    {
        //Set as Primary Key
        //[Key]
        //Match to Column
        //[Column("cat_id")]
        //Set Identity
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        //Set Column Type
        //[Column(TypeName = "nText")]
        //Set Display
        [Display(Name = "ชื่อประเภทสินค้า")]
        [Required(ErrorMessage = "กรุณากรอกชื่อประเภทสินค้า")]
        public string CategoryName { get; set; }
    }
}
