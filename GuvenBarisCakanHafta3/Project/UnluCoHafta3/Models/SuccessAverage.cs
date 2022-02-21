using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UnluCoHafta3.Models
{
    [Index(nameof(StudentId),IsUnique = true)]
    [Table("SuccessAverages")]
    public class SuccessAverage
    {
        [Key]
        public int AverageId { get; set; }
        public int AveragePercent { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
