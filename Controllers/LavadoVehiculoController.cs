using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PabloCortes_Proyecto1.Models;
using System.Linq;

namespace PabloCortes_Proyecto1.Controllers
{
    public class LavadoVehiculoController : Controller
    {
        private static List<LavadoVehiculo> lavados = new List<LavadoVehiculo>();
        // GET: LavadoVehiculoController
        public ActionResult Index(int? idSearch)
        {
            IEnumerable<LavadoVehiculo> model = lavados;
            if (idSearch.HasValue)
            {
                model = lavados.Where(l => l.IdLavado == idSearch.Value);
            }
            return View(model);
        }

        // GET: LavadoVehiculoController/Details/5
        public ActionResult Details(int id)
        {
            var lavado = lavados.FirstOrDefault(l => l.IdLavado == id);
            if (lavado == null)
            {
                return NotFound();
            }
            return View(lavado);
        }

        // GET: LavadoVehiculoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LavadoVehiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LavadoVehiculo lavado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Depuración: Mostrar los valores recibidos
                    Console.WriteLine($"TipoLavado: {lavado.TipoLavado}, Precio: {lavado.Precio}, Raw Precio: {Request.Form["Precio"]}");

                    // Validar que para "Joya" se ingrese un precio
                    if (lavado.TipoLavado == "Joya" && lavado.Precio <= 0)
                    {
                        ModelState.AddModelError("Precio", "Debe ingresar un precio válido para el tipo Joya.");
                        return View(lavado);
                    }

                    // Asegurarse de que IdLavado sea único (simulación)
                    if (lavado.IdLavado == 0)
                    {
                        lavado.IdLavado = lavados.Count > 0 ? lavados.Max(l => l.IdLavado) + 1 : 1;
                    }

                    // Agregar el lavado
                    lavados.Add(lavado);
                    return RedirectToAction(nameof(Index));
                }
                // Mostrar errores de validación
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error de validación: {error.ErrorMessage}");
                }
                return View(lavado);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el lavado: " + ex.Message);
                Console.WriteLine($"Excepción: {ex.ToString()}");
                return View(lavado);
            }
        }

        // GET: LavadoVehiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            var lavado = lavados.FirstOrDefault(l => l.IdLavado == id);
            if (lavado == null)
            {
                return NotFound();
            }
            return View(lavado);
        }

        // POST: LavadoVehiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LavadoVehiculo lavado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine($"TipoLavado: {lavado.TipoLavado}, Precio: {lavado.Precio}, Raw Precio: {Request.Form["Precio"]}");
                    if (lavado.TipoLavado == "Joya" && lavado.Precio <= 0)
                    {
                        ModelState.AddModelError("Precio", "Debe ingresar un precio válido para el tipo Joya.");
                        return View(lavado);
                    }
                    var existingLavado = lavados.FirstOrDefault(l => l.IdLavado == id);
                    if (existingLavado != null)
                    {
                        existingLavado.PlacaVehiculo = lavado.PlacaVehiculo;
                        existingLavado.IdCliente = lavado.IdCliente;
                        existingLavado.IdEmpleado = lavado.IdEmpleado;
                        existingLavado.TipoLavado = lavado.TipoLavado;
                        existingLavado.Precio = lavado.Precio;
                        existingLavado.EstadoLavado = lavado.EstadoLavado;
                    }
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error de validación: {error.ErrorMessage}");
                }
                return View(lavado);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al editar el lavado: " + ex.Message);
                Console.WriteLine($"Excepción: {ex.ToString()}");
                return View(lavado);
            }
        }

        // GET: LavadoVehiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            var lavado = lavados.FirstOrDefault(l => l.IdLavado == id);
            if (lavado == null)
            {
                return NotFound();
            }
            return View(lavado);
        }

        // POST: LavadoVehiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var lavado = lavados.FirstOrDefault(l => l.IdLavado == id);
                if (lavado != null)
                {
                    lavados.Remove(lavado);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
