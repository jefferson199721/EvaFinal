using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaFinal.Data;
using EvaFinal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaFinal.Controllers
{
    public class ExamenesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ExamenModel _Examen_model;
        public ExamenesController(ApplicationDbContext context)
        {
            _context = context;
            _Examen_model = new ExamenModel(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Examen.ToListAsync());
        }
        public IdentityError Nuevo_Examen_Controller(string NPreguntas, string Fecha)
        {
            return _Examen_model.Nuevo_Examen_Model(NPreguntas,Fecha);

        }
        //public Profesor Un_Examen_Controller(int ExamenId)
        //{
        //    //return _Examen_model.Un_Examen_Model(ExamenId);
        //}
        public IdentityError Editar_Examen_Controller(int ExamenId, string NPreguntas,string Fecha)
        {
            return _Examen_model.Editar_Examen_Model(ExamenId, NPreguntas,Fecha);

        }
        public IdentityError Eliminar_Examen_Controller(int ExamenId)
        {
            return _Examen_model.Eliminar_Examen_Model(ExamenId);
        }
        public List<object[]> Lista_Examen_Controller()
        {
            return _Examen_model.Lista_Examen_Model();
        }





    }
}