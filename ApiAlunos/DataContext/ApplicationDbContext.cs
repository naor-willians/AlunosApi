﻿using ApiAlunos.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiAlunos.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 
        }
        
        public DbSet<AlunoModel> Alunos { get; set; }
    }
}
