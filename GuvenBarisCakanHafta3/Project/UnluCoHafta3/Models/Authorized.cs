using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace UnluCoHafta3.Models
{
    [Index(nameof(PersonelInformationId),IsUnique = true)]
    [Table("Authorities")]
    public class Authorized
    {
        [Key]
        public int AuthorizedId { get; set; }
        public int PersonelInformationId { get; set; }
        [Required]
        public float Degree { get; set; }
        public virtual PersonelInformation PersonelInformation { get; set; }
    }
}

