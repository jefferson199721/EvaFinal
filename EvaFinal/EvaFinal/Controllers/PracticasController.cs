using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaFinal.Data;
using EvaFinal.Models;
using Microsoft.AspNetCore.Identity;

namespace EvaFinal.Controllers
{
  
    public class PracticasController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly PracticaModel _practicas_model;
        public PracticasController(ApplicationDbContext context)
        {
            _context = context;
            _practicas_model = new PracticaModel(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Practica.ToListAsync());
        }

        public IdentityError Nuevo_Practica_Controller(string Titulo, string Nota, string Dificultad, DateTime FechaDiseño)
        {
            return _practicas_model.Nuevo_Practica_Model(Titulo, Nota, Dificultad, FechaDiseño);
        }

        public Practica Un_Practica_Controller(int PracticaId)
        {
            return _practicas_model.Un_Practica_Model(PracticaId);
        }

        public IdentityError Editar_Practica_Controller(int PracticaId, string Titulo, string Nota, string Dificultad, DateTime FechaDiseño)
        {
            return _practicas_model.Editar_Practica_Model(PracticaId, Titulo, Nota, Dificultad, FechaDiseño);

        }
        public IdentityError Eliminar_Practica_Controller(int PracticaId)
        {
            return _practicas_model.Eliminar_Practica_Model(PracticaId);
        }
        public List<object[]> Lista_Practica_Controller()
        {
            return _practicas_model.Lista_Practica_Model();
        }

    }
}
