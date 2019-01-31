using EvaFinal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace EvaFinal.Models
{
    public class haceModel
    {
        public ApplicationDbContext _contexto;

        public haceModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_hace_Model(
            string Nota,
            int NumMatricula,
            int ExamenId)
        {
            IdentityError resultado = new IdentityError();
            hace hace = new hace()
            {
                Nota = Nota,
                NumMatricula= NumMatricula,
                ExamenId = ExamenId

            };
            try
            {

                _contexto.Hacer.Add(hace);
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

        public hace Un_Hace_Model(int hacerid)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            hace hace = (from hc in _contexto.Hacer
                               where hc.hacerid == hacerid
                            select hc).FirstOrDefault();
            return hace;
        }

        public IdentityError Editar_Hace_Model(
            int hacerid,
            int NumMatricula,
            int ExamenId,
            string Notas)
        {
            IdentityError resultado = new IdentityError();
            hace hace = new hace()
            {
                Nota = Notas,
                NumMatricula = NumMatricula,
                ExamenId = ExamenId
            };
            try
            {
                _contexto.Hacer.Update(hace);
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
        public IdentityError Eliminar_hace_Model(
           int hacerid)
        {
            IdentityError resultado = new IdentityError();
            hace hace = new hace()
            {
                hacerid = hacerid
            };
            try
            {
                _contexto.Hacer.Remove(hace);
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



        public List<object[]> Lista_Hace_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var hace = _contexto.Hacer.ToList();

            foreach (var item in hace)
            {
          
                dato += "<tr>" +
                    "<td>" + item. Nota+ "</td>" +
                    "<td>" + item.NumMatricula  + "</td>" +
                    "<td>" + item.ExamenId + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Hace' " +
                    "onclick ='Un_Hace(" + item.hacerid + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_Hace(" + item.hacerid + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
