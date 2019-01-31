using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaFinal.Models
{
    public class Alumnos
    {
        [Key]
        public int NumMatricula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CursoParalelo { get; set; }
      
      

    }
}
