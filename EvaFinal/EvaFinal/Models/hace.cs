using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaFinal.Models
{
    public class hace
    {
        [Key]
        public int hacerid { get; set; }
        public int NumMatricula  { get; set; }
        public Alumnos alumnos { get; set; }
        public int ExamenId { get; set; }
        public Examen examen { get; set; }
        public string Nota { get; set; }
        
    }
}
