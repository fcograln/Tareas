using System.ComponentModel.DataAnnotations;

namespace TaskMVC.Models
{
    public class Tarea
    {
    [Key]
    public int IdTarea { get; set; }
    [Required]
    public string Titulo { get; set; }
    [Required]
    public string Descripcion { get; set; }
    public bool Completada { get; set; }

    }

    public class NuevaTarea
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
    }
}