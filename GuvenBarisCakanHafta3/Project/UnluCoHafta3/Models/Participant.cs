using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UnluCoHafta3.Models
{
    [Index(nameof(PersonelInformationId), IsUnique = true)]
    [Table("Participants")]
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }
        public int PersonelInformationId { get; set; }
        public virtual PersonelInformation PersonelInformation { get; set; }
        public virtual IEnumerable<Education> Educations { get; set; }
    }
}
