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

        public IdentityError Nuevo_Cliente_Model(
            string Nombres,
            string Apellidos,
            string CursoParalelo)
        {
            IdentityError resultado = new IdentityError();
            Alumnos cliente = new Alumnos()
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                CursoParalelo = CursoParalelo

            };
            try
            {

                _contexto.Alumnos.Add(cliente);
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

        public Cliente Un_Cliente_Model(int ClienteId)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Cliente cliente = (from c in _contexto.Cliente
                               where c.ClienteId == ClienteId
                               select c).FirstOrDefault();
            return cliente;
        }

        public IdentityError Editar_Cliente_Model(
            int ClienteId,
            string Nombres,
            string Apellidos,
            string Telefono,
            string Correo,
            string Categoria,
            string Garantia,
            DateTime FechaIngreso)
        {
            IdentityError resultado = new IdentityError();
            Cliente cliente = new Cliente()
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                Telefono = Telefono,
                Correo = Correo,
                Categoria = Categoria,
                Garantia = Garantia,
                FechaIngreso = FechaIngreso,
                ClienteId = ClienteId


            };
            try
            {
                _contexto.Cliente.Update(cliente);
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
        public IdentityError Eliminar_Cliente_Model(
           int clienteId)
        {
            IdentityError resultado = new IdentityError();
            Cliente cliente = new Cliente()
            {
                ClienteId = clienteId
            };
            try
            {
                _contexto.Cliente.Remove(cliente);
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



        public List<object[]> Lista_Cliente_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var clientes = _contexto.Cliente.ToList();

            foreach (var item in clientes)
            {
                dato += "<tr>" +
                    "<td>" + item.Nombres + "</td>" +
                    "<td>" + item.Apellidos + "</td>" +
                    "<td>" + item.Telefono + "</td>" +
                    "<td>" + item.Correo + "</td>" +
                    "<td>" + item.Categoria + "</td>" +
                    "<td>" + item.Garantia + "</td>" +
                    "<td>" + item.FechaIngreso + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Cliente' " +
                    "onclick ='Un_Cliente(" + item.ClienteId + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_cliente(" + item.ClienteId + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}

