using ManyToMany2.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany2.Data
{
    public class PCContext :DbContext
    {
        public  PCContext(DbContextOptions<PCContext> options):base(options)
        {
        
        }

        public DbSet<Projet> Projets { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ProjetConsultant> ProjetConsultants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjetConsultant>()
                 .HasKey(pc => new { pc.ProjetId, pc.ConsultantId });

            modelBuilder.Entity<ProjetConsultant>()
                .HasOne(p =>p.Projet)
                .WithMany(pc => pc.ProjetConsultant)
                .HasForeignKey(po => po.ProjetId);


            modelBuilder.Entity<ProjetConsultant>()
                .HasOne(p => p.Consultant)
                .WithMany(pc => pc.ProjetConsultant)
                .HasForeignKey(po => po.ConsultantId);


        }

       
    }
}
