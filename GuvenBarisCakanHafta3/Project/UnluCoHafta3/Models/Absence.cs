using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UnluCoHafta3.Models
{
    [Index(nameof(StudentId),IsUnique = true)]
    [Table("Absences")]
    public class Absence
    {
        [Key]
        public int AbsenceId { get; set; }
        public int NumberOfWeek { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
