using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Db.Model
{
    public class Admine
    {
        [Key]
        public int AdmineId { get; set; }
        public String AdmineName { get; set; }
       
    }
}
