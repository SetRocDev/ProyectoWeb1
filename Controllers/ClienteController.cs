using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PabloCortes_Proyecto1.Models;
using System.Linq;

namespace PabloCortes_Proyecto1.Controllers
{
    public class ClienteController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();
        // GET: ClienteController
        public ActionResult Index(string searchIdentificacion, string searchNombre)
        {
            IEnumerable<Cliente> modelo;
            if (!string.IsNullOrEmpty(searchIdentificacion) || !string.IsNullOrEmpty(searchNombre))
            {
                modelo = clientes.Where(c => (string.IsNullOrEmpty(searchIdentificacion) || c.Identificacion.Contains(searchIdentificacion)) &&
                                            (string.IsNullOrEmpty(searchNombre) || c.NombreCompleto.Contains(searchNombre)));
            }
            else
            {
                modelo = clientes;
            }
            return View(modelo);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(string id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Identificacion == id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }
            return View(cliente); // Pasa el cliente encontrado a la vista
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clientes.Add(cliente); // Agrega el cliente a la lista
                    return RedirectToAction(nameof(Index)); // Redirige a la lista
                }
                return View(cliente); // Vuelve a la vista con el cliente si hay errores
            }
            catch
            {
                return View(cliente); // Vuelve a la vista si hay un error
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(string id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Identificacion == id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404
            }
            return View(cliente); // Pasa el cliente a la vista para edición
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clienteExistente = clientes.FirstOrDefault(c => c.Identificacion == id);
                    if (clienteExistente != null)
                    {
                        // Actualiza los valores del cliente existente
                        clienteExistente.Identificacion = cliente.Identificacion;
                        clienteExistente.NombreCompleto = cliente.NombreCompleto;
                        clienteExistente.Provincia = cliente.Provincia;
                        clienteExistente.Canton = cliente.Canton;
                        clienteExistente.Distrito = cliente.Distrito;
                        clienteExistente.DireccionExacta = cliente.DireccionExacta;
                        clienteExistente.Telefono = cliente.Telefono;
                        clienteExistente.PreferenciaLavado = cliente.PreferenciaLavado;
                    }
                    return RedirectToAction(nameof(Index)); // Redirige a la lista
                }
                return View(cliente); // Vuelve a la vista si hay errores
            }
            catch
            {
                return View(cliente); // Vuelve a la vista si hay un error
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(string id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Identificacion == id);
            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }
            return View(cliente); // Pasa el cliente a la vista para confirmación
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var cliente = clientes.FirstOrDefault(c => c.Identificacion == id);
                if (cliente != null)
                {
                    clientes.Remove(cliente); // Elimina el cliente de la lista
                }
                return RedirectToAction(nameof(Index)); // Redirige a la lista
            }
            catch
            {
                return View(); // Vuelve a la vista si hay un error
            }
        }
    }
}
