using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Aluno>().HasData(

                new Aluno
                {
                    Id = 1,
                    Name = "Aline Silva",
                    Email = "alinesilva@hotmail.com",
                    Idade = 19
                },
                new Aluno
                {
                    Id = 2,
                    Name = "Bruna Ellen",
                    Email = "brunnaellen@gmail.com",
                    Idade = 20
                },
                 new Aluno
                 {
                     Id = 3,
                     Name = "Carlos Juan",
                     Email = "carlinhos@gmail.com",
                     Idade = 18
                 }

            );

        }
    }
}
