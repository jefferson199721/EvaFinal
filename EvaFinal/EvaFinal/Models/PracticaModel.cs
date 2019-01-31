using EvaFinal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaFinal.Models
{
    public class PracticaModel
    {
        public ApplicationDbContext _contexto;

        public PracticaModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Practica_Model(
            string Titulo,
            string Nota,
            string Dificultad,
            DateTime FechaDiseño)
        {
            IdentityError resultado = new IdentityError();
            Practica practica = new Practica()
            {
                Titulo = Titulo,
                Nota = Nota,
                Dificultad = Dificultad,
                FechaDiseño = FechaDiseño
            };
            try
            {

                _contexto.Practica.Add(practica);
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

        public Practica Un_Practica_Model(int PracticaId)
        {            
            Practica practica = (from pra in _contexto.Practica
                               where pra.PracticaId == PracticaId
                               select pra).FirstOrDefault();
            return practica;
        }

        public IdentityError Editar_Practica_Model(
            int PracticaId,
            string Titulo,
            string Nota,
            string Dificultad,
            DateTime FechaDiseño)
        {
            IdentityError resultado = new IdentityError();
            Practica practica = new Practica()
            {
                Titulo = Titulo,
                Nota = Nota,
                Dificultad = Dificultad,
                FechaDiseño = FechaDiseño,
                PracticaId = PracticaId
            };
            try
            {
                _contexto.Practica.Update(practica);
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
        public IdentityError Eliminar_Practica_Model(
           int PracticaId)
        {
            IdentityError resultado = new IdentityError();
            Practica practica = new Practica()
            {
                PracticaId = PracticaId
            };
            try
            {
                _contexto.Practica.Remove(practica);
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



        public List<object[]> Lista_Practica_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var practica = _contexto.Practica.ToList();

            foreach (var item in practica)
            {
                dato += "<tr>" +
                    "<td>" + item.Titulo + "</td>" +
                    "<td>" + item.Nota + "</td>" +
                    "<td>" + item.Dificultad + "</td>" +
                    "<td>" + item.FechaDiseño + "</td>" +              
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Practica' " +
                    "onclick ='Un_Practica(" + item.PracticaId + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_practica(" + item.PracticaId + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
