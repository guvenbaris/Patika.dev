using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnluCoHafta3.Models
{
    [Table("Educations")]
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        [Required]
        [StringLength(50)]
        public string EducationName { get; set; }
        [Required]
        public string EducationContent { get; set; }
        public int TeacherId { get; set; }
        public int AssistantId { get; set; }
        public int AuthorizedId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public  virtual Assistant Assistant { get; set; }
        public virtual Authorized Authorized { get; set; }
        public DateTime StartingDateTime { get; set; }
        public DateTime ExpirationDate { get; set; }
        public virtual IEnumerable<Participant> Participants { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
    }
}

