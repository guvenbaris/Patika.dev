using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UnluCoHafta3.Models
{
    [Table("PersonelInformations")]
    public class PersonelInformation
    {
        [Key]
        public int PersonelInformationId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Telephone { get; set; }
        public  DateTime DateJoined { get; set; }
    }
}
