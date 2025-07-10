using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PabloCortes_Proyecto1.Models;
using System.Linq;

namespace PabloCortes_Proyecto1.Controllers
{
    public class VehiculoController : Controller
    {
        private static List<Vehiculo> vehiculos = new List<Vehiculo>();
        // GET: VehiculoController
        public ActionResult Index(string placaSearch)
        {
            IEnumerable<Vehiculo> model = vehiculos;
            if (!string.IsNullOrEmpty(placaSearch))
            {
                model = vehiculos.Where(v => v.Placa == placaSearch);
            }
            return View(model);
        }

        // GET: VehiculoController/Details/5
        public ActionResult Details(string placa)
        {
            var vehiculo = vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // GET: VehiculoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehiculo vehiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(vehiculo.Placa))
                    {
                        ModelState.AddModelError("Placa", "La placa es obligatoria.");
                        return View(vehiculo);
                    }
                    if (vehiculos.Any(v => v.Placa == vehiculo.Placa))
                    {
                        ModelState.AddModelError("Placa", "La placa ya está registrada.");
                        return View(vehiculo);
                    }
                    vehiculo.UltimaFechaAtencion = DateTime.Now; // Establecer fecha actual por defecto
                    vehiculos.Add(vehiculo);
                    return RedirectToAction(nameof(Index));
                }
                return View(vehiculo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el vehículo: " + ex.Message);
                return View(vehiculo);
            }
        }

        // GET: VehiculoController/Edit/5
        public ActionResult Edit(string placa)
        {
            var vehiculo = vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: VehiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string placa, Vehiculo vehiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(vehiculo.Placa))
                    {
                        ModelState.AddModelError("Placa", "La placa es obligatoria.");
                        return View(vehiculo);
                    }
                    var existingVehiculo = vehiculos.FirstOrDefault(v => v.Placa == placa);
                    if (existingVehiculo != null)
                    {
                        // Actualizar solo si la placa no cambia o no está duplicada
                        if (placa != vehiculo.Placa && vehiculos.Any(v => v.Placa == vehiculo.Placa))
                        {
                            ModelState.AddModelError("Placa", "La nueva placa ya está registrada.");
                            return View(vehiculo);
                        }
                        existingVehiculo.Marca = vehiculo.Marca;
                        existingVehiculo.Modelo = vehiculo.Modelo;
                        existingVehiculo.Traccion = vehiculo.Traccion;
                        existingVehiculo.Color = vehiculo.Color;
                        existingVehiculo.UltimaFechaAtencion = vehiculo.UltimaFechaAtencion;
                        existingVehiculo.TratamientoNanoCeramico = vehiculo.TratamientoNanoCeramico;
                        if (placa != vehiculo.Placa)
                        {
                            vehiculos.Remove(existingVehiculo);
                            vehiculos.Add(vehiculo);
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(vehiculo);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al editar el vehículo: " + ex.Message);
                return View(vehiculo);
            }
        }

        // GET: VehiculoController/Delete/5
        public ActionResult Delete(string placa)
        {
            var vehiculo = vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: VehiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string placa, IFormCollection collection)
        {
            try
            {
                var vehiculo = vehiculos.FirstOrDefault(v => v.Placa == placa);
                if (vehiculo != null)
                {
                    vehiculos.Remove(vehiculo);
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
