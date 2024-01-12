using Microsoft.EntityFrameworkCore;
using TaskMVC.Models;

namespace TaskMVC
{
    public class TareaDbContext: DbContext
    {
        public TareaDbContext(DbContextOptions<TareaDbContext> options) : base(options) { }
        public DbSet<Tarea> Tareas { get; set; }
    
    }
}