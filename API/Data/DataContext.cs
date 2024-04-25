using ListaTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarefas.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ListaTarefas> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=icecream.sqlite;Cache=Shared");
    }
}