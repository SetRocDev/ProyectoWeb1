using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PabloCortes_Proyecto1.Models;
using System.Linq;

namespace PabloCortes_Proyecto1.Controllers
{
    public class EmpleadoController : Controller
    {
        private static List<Empleado> empleados = new List<Empleado>();

        // GET: EmpleadoController
        public ActionResult Index(string searchCedula)
        {
            IEnumerable<Empleado> modelo;
            if (!string.IsNullOrEmpty(searchCedula))
            {
                modelo = empleados.Where(e => e.Cedula.Contains(searchCedula));
            }
            else
            {
                modelo = empleados;
            }
            return View(modelo);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(string cedula)
        {
            var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleados.Add(empleado);
                    return RedirectToAction(nameof(Index));
                }
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(string cedula)
        {
            var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string cedula, Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var empleadoExistente = empleados.FirstOrDefault(e => e.Cedula == cedula);
                    if (empleadoExistente != null)
                    {
                        empleadoExistente.Cedula = empleado.Cedula;
                        empleadoExistente.FechaNacimiento = empleado.FechaNacimiento;
                        empleadoExistente.FechaIngreso = empleado.FechaIngreso;
                        empleadoExistente.SalarioPorDia = empleado.SalarioPorDia;
                        empleadoExistente.DiasVacacionesAcumulados = empleado.DiasVacacionesAcumulados;
                        empleadoExistente.FechaRetiro = empleado.FechaRetiro;
                        empleadoExistente.MontoLiquidacion = empleado.MontoLiquidacion;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(string cedula)
        {
            var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string cedula, IFormCollection collection)
        {
            try
            {
                var empleadoExistente = empleados.FirstOrDefault(e => e.Cedula == cedula);
                if (empleadoExistente != null)
                {
                    empleados.Remove(empleadoExistente);
                    return RedirectToAction(nameof(Index));
                }
                return NotFound(); // Si no se encuentra, muestra el error 404
            }
            catch
            {
                return View(empleados); // Vuelve a la vista si hay un error
            }
        }
    }
}
