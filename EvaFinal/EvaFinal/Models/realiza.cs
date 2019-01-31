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
        public int PracticaId { get; set; }
        public string fecha { get; set; }
        public string nota { get; set; }
    }
}
