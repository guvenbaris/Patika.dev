using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UnluCoHafta3.Models
{
    public class PatikaDevDbContext : DbContext
    {
        public PatikaDevDbContext(DbContextOptions<PatikaDevDbContext> options):base(options)
        {
            
        }

        public DbSet<Authorized> Authorities { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<PersonelInformation> PersonelInformations { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SuccessAverage> SuccessAverages { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}
