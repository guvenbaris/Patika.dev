using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UnluCoHafta3.Models
{
    [Index(nameof(PersonelInformationId),IsUnique = true)]
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string ComputerKnowledge { get; set; }
        public int PersonelInformationId { get; set; }
        public virtual PersonelInformation PersonelInformation { get; set; }
    }
}
