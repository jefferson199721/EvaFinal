using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaFinal.Models
{
    public class Examen
    {
        [Key]
        public int ExamenId { get; set; }
        public string NPreguntas { get; set; }
        public string Fecha { get; set; }



    }
}
