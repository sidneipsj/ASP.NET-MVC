using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD.CodeFirstExample.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=DbConnectionString")
        {
        }
        public DbSet<Teacher> Publishers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasKey(t => t.TeacherId); //primary key defination  
            modelBuilder.Entity<Teacher>().Property(t => t.TeacherId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);  //identity col            
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);
            modelBuilder.Entity<Student>().Property(s => s.StudentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}