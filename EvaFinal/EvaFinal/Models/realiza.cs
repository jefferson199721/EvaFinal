using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaFinal.Models
{
    public class realiza
    {
        public int realizaId { get; set; }
        public int AlumnosId { get; set; }
        public Alumnos alumnos { get; set; }
        public int PracticaId { get; set; }
        public Practica practica { get; set; }
        public DateTime fecha { get; set; }
        public string nota { get; set; }
    }
}
