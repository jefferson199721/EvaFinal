using EvaFinal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaFinal.Models
{
    public class ExamenModel
    {

        public ApplicationDbContext _contexto;
  

        public ExamenModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Examen_Model(
            string NPreguntas,
            string Fecha)
        {
            IdentityError resultado = new IdentityError();
            Examen examen = new Examen()
            {
                NPreguntas = NPreguntas,
                Fecha=Fecha

            };
            try
            {

                _contexto.Examen.Add(examen);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Guardo con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }

        public Examen Un_Examen_Model(int ExamenId)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Examen examen = (from pr in _contexto.Examen
                                 where pr.ExamenId == ExamenId
                                 select pr).FirstOrDefault();
            return examen;
        }

        public IdentityError Editar_Examen_Model(
            int ExamenId,

            string NPreguntas,
            string Fecha)
        {
            IdentityError resultado = new IdentityError();
            Examen examen = new Examen()
            {
                 NPreguntas= NPreguntas,
                 Fecha=Fecha,
                ExamenId = ExamenId
            };
            try
            {
                _contexto.Examen.Update(examen);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Actualizo con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }
        public IdentityError Eliminar_Examen_Model(
           int ExamenId)
        {
            IdentityError resultado = new IdentityError();
            Examen examen = new Examen()
            {
                ExamenId = ExamenId
            };
            try
            {
                _contexto.Examen.Remove(examen);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Elimino con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }

        public List<object[]> Lista_Examen_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var examen = _contexto.Examen.ToList();

            foreach (var item in examen)
            {
                dato += "<tr>" +
                    "<td>" + item.NPreguntas + "</td>" +
                    "<td>" + item.Fecha + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Profesor' " +
                    "onclick ='Un_Profesor(" + item.ExamenId + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_profesor(" + item.ExamenId + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
