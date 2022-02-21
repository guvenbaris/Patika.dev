using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UnluCoHafta3.Models
{
    [Index(nameof(PersonelInformationId),IsUnique = true)]
    [Table("Assistants")]
    public class Assistant
    {
        [Key]
        public int AssistantId { get; set; }
        public int PersonelInformationId { get; set; }
        public virtual PersonelInformation PersonelInformation { get; set; }

    }
}
