using Microsoft.AspNetCore.Mvc;
using TaskMVC.Models;


namespace TaskMVC.Controllers
{
    [Route("[controller]")]
    public class TareaController : Controller
    {
   
        private readonly TareaDbContext _context;
        public TareaController( TareaDbContext context)
        {
            _context= context;
        }

      [HttpGet]
    public IActionResult Index()
    {
        return View(_context.Tareas.ToList());
    }

[HttpPost]
    public async Task<IActionResult> NuevaTarea([Bind("Titulo, Descripcion")] Tarea nuevaTarea)
    {
        if (ModelState.IsValid)
        {
            _context.Tareas.Add(nuevaTarea);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }

[HttpPost]
    [Route("CompletarTarea/{id}")]
    public async Task<IActionResult> CompletarTarea(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea != null)
        {
            tarea.Completada = true;
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        return Json(new { success = false, error = "No se encontró la tarea" });
    }

[HttpPost]
    [Route("EliminarTarea/{id}")]
    public async Task<IActionResult> EliminarTarea(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea != null)
        {
            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        return Json(new { success = false, error = "No se encontró la tarea" });
    }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}