using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UnluCoHafta3.Models
{
    [Index(nameof(PersonelInformationId), IsUnique = true)]
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public int PersonelInformationId { get; set; } 
        public bool WorkingStatus { get; set; }
        public virtual PersonelInformation PersonelInformation { get; set; }
        public virtual IEnumerable<Education> Educations { get; set; }
    }
}
