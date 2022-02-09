using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Db.Model
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public String ClassName { get; set; }
    }
}
