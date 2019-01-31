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
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        private readonly AlumnosModel _alumnos_model;

        public AlumnosController(ApplicationDbContext context)
        {
            _context = context;
            _alumnos_model = new AlumnosModel(context);
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alumnos.ToListAsync());
        }

        public IdentityError Nuevo_Alumnos_Controller(string Nombres, string Apellidos, string CursoParalelo)
        {
            return _alumnos_model.Nuevo_Alumno_Model(Nombres, Apellidos, CursoParalelo);

        }

        public Alumnos Un_Alumno_Controller(int NumMatricula)
        {
            return _alumnos_model.Un_Alumno_Model(NumMatricula);
        }
        public IdentityError Editar_Alumnos_Controller(int NumMatricula, string Nombres, string Apellidos,
            string CursoParalelo)
        {
            return _alumnos_model.Editar_Alumnos_Model(NumMatricula, Nombres, Apellidos, CursoParalelo);

        }
        public IdentityError Eliminar_Alumnos_Controller(int NumMatricula)
        {
            return _alumnos_model.Eliminar_Cliente_Model(NumMatricula);
        }
        public List<object[]> Lista_Alumnos_Controller()
        {
            return _alumnos_model.Lista_Alumnos_Model();
        }
    }
}
