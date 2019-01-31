using EvaFinal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaFinal.Models
{
    public class ProfesoresModel
    {
        public ApplicationDbContext _contexto;

        public ProfesoresModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Profesor_Model(
            string Nombre)
        {
            IdentityError resultado = new IdentityError();
            Profesor profesor = new Profesor()
            {
                Nombre = Nombre

            };
            try
            {

                _contexto.Profesor.Add(profesor);
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

        public Profesor Un_Profesor_Model(int ProfesorId)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Profesor profesor = (from pr in _contexto.Profesor
                               where pr.ProfesorId == ProfesorId
                               select pr).FirstOrDefault();
            return profesor;
        }

        public IdentityError Editar_Profesor_Model(
            int ProfesorId,
            string Nombre)
        {
            IdentityError resultado = new IdentityError();
            Profesor profesor = new Profesor()
            {
                Nombre = Nombre,                
                ProfesorId = ProfesorId
            };
            try
            {
                _contexto.Profesor.Update(profesor);
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
        public IdentityError Eliminar_Profesor_Model(
           int ProfesorId)
        {
            IdentityError resultado = new IdentityError();
            Profesor profesor = new Profesor()
            {
                ProfesorId = ProfesorId
            };
            try
            {
                _contexto.Profesor.Remove(profesor);
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

        public List<object[]> Lista_Profesor_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var profesor = _contexto.Profesor.ToList();

            foreach (var item in profesor)
            {
                dato += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +                    
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Profesor' " +
                    "onclick ='Un_Profesor(" + item.ProfesorId + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_profesor(" + item.ProfesorId + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
