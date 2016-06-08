using System;
using System.Data.Entity;
using System.Linq;

namespace UnitOfWorkDemo.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() : base("DefaultConnection")
		{
			
		}

		public DbSet<Post> Posts { get; set; }
		public DbSet<Comentario> Comentarios { get; set; }


		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("DataCriacao").CurrentValue = DateTime.Now;
				}

				if (entry.State == EntityState.Modified)
				{
					entry.Property("DataCriacao").IsModified = false;
				}
			}
			return base.SaveChanges();
		}
	}
}
