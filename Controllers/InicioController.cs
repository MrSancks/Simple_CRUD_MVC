﻿using CrudMVC.Data;
using CrudMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudMVC.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public InicioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Contacts.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contact contacto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Contacts.Add(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var contacto = _contexto.Contacts.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contact contacto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _contexto.Contacts.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _contexto.Contacts.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _contexto.Contacts.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }

            // borrar usuario
            _contexto.Contacts.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}