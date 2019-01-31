using EvaFinal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaFinal.Models
{
    public class AlumnosModel
    {
        public ApplicationDbContext _contexto;

        public AlumnosModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Alumno_Model(
            string Nombres,
            string Apellidos,
            string CursoParalelo)
        {
            IdentityError resultado = new IdentityError();
            Alumnos alumnos = new Alumnos()
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                CursoParalelo = CursoParalelo

            };
            try
            {

                _contexto.Alumnos.Add(alumnos);
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

        public Alumnos Un_Alumno_Model(int NumMatricula)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Alumnos alumnos = (from al in _contexto.Alumnos
                               where al.NumMatricula == NumMatricula
                               select al).FirstOrDefault();
            return alumnos;
        }

        public IdentityError Editar_Alumnos_Model(
            int NumMatricula,
            string Nombres,
            string Apellidos,
            string CursoParalelo)
        {
            IdentityError resultado = new IdentityError();
            Alumnos alumnos = new Alumnos()
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                CursoParalelo = CursoParalelo,
                NumMatricula = NumMatricula
            };
            try
            {
                _contexto.Alumnos.Update(alumnos);
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
        public IdentityError Eliminar_Alumnos_Model(
           int NumMatricula)
        {
            IdentityError resultado = new IdentityError();
            Alumnos alumnos = new Alumnos()
            {
                NumMatricula = NumMatricula
            };
            try
            {
                _contexto.Alumnos.Remove(alumnos);
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



        public List<object[]> Lista_Alumnos_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var alumnos = _contexto.Alumnos.ToList();

            foreach (var item in alumnos)
            {
                dato += "<tr>" +
                    "<td>" + item.Nombres + "</td>" +
                    "<td>" + item.Apellidos + "</td>" +
                    "<td>" + item.CursoParalelo + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Alumnos' " +
                    "onclick ='Un_Cliente(" + item.NumMatricula + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_cliente(" + item.NumMatricula + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}

