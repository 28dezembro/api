using Tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarefas.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ListaTarefas> ListaTarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tarefas.sqlite;Cache=Shared");
    }
}