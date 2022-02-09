using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Db.Model
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }
        public string ProfessorName { get; set; }

    }
}
