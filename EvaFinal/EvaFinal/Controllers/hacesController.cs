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
    public class hacesController : Controller
    {
        public class ProfesoresController : Controller
        {
            private readonly ApplicationDbContext _context;


            private readonly haceModel _haces_model;

            public ProfesoresController(ApplicationDbContext context)
            {
                _context = context;
                _haces_model = new haceModel(context);
            }

            public async Task<IActionResult> Index()
            {
                return View(await _context.Hacer.ToListAsync());
            }

            public IdentityError Nuevo_Hace_Controller(string nota, int NumMatricula, int ExamenId)
            {
                return _haces_model.Nuevo_hace_Model(nota, NumMatricula, ExamenId);

            }

            //public Profesor Un_Hace_Controller(int (hacerid)
            //{
            //    return _haces_model.Un_Hace_Model(hacerid);
            //}
            //public IdentityError Editar_Profesor_Controller(int hacerid, string Nombre)
            //{
            //    return _haces_model.Editar_Hace_Model(hacerid, Nombre);

            //}
            public IdentityError Eliminar_hacer_Controller(int hacerid)
            {
                return _haces_model.Eliminar_hace_Model(hacerid);
            }
            public List<object[]> Lista_hace_Controller()
            {
                return _haces_model.Lista_Hace_Model();
            }
        }
    }
}
