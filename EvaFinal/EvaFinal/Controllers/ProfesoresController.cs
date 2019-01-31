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
    public class ProfesoresController : Controller
    {
        private readonly ApplicationDbContext _context;


        private readonly ProfesoresModel _profesor_model;

        public ProfesoresController(ApplicationDbContext context)
        {
            _context = context;
            _profesor_model = new ProfesoresModel(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesor.ToListAsync());
        }

        public IdentityError Nuevo_Profesor_Controller(string Nombre)
        {
            return _profesor_model.Nuevo_Profesor_Model(Nombre);

        }

        public Profesor Un_Profesor_Controller(int ProfesorId)
        {
            return _profesor_model.Un_Profesor_Model(ProfesorId);
        }
        public IdentityError Editar_Profesor_Controller(int ProfesorId, string Nombre)
        {
            return _profesor_model.Editar_Profesor_Model(ProfesorId, Nombre);

        }
        public IdentityError Eliminar_Profesor_Controller(int ProfesorId)
        {
            return _profesor_model.Eliminar_Profesor_Model(ProfesorId);
        }
        public List<object[]> Lista_Profesor_Controller()
        {
            return _profesor_model.Lista_Profesor_Model();
        }
    }
}
