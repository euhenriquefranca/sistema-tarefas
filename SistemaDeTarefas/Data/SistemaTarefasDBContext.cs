using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
	public class SistemaTarefasDBContext : DbContext
	{
		public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
			: base(options)
		{
		}
		public DbSet<UsuarioModel> Usuarios { get; set; }
		public DbSet<TarefaModel> Tarefas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UsuarioMap());
			modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
		}

    }
    public class YourDbContextFactory : IDesignTimeDbContextFactory<SistemaTarefasDBContext>
    {
        public SistemaTarefasDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SistemaTarefasDBContext>();
            optionsBuilder.UseSqlServer("Server=./;Database=DB_SistemaTarefas;User Id=sa;Password=r00t.R00T;");

            return new SistemaTarefasDBContext(optionsBuilder.Options);
        }
    }
}

