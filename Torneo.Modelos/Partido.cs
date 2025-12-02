using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Modelos
{
    public class Partido
    {
        [Key] public int Id { get; set; }
        public int EquiposId { get; set; }
                
        public int TorneoId { get; set; }
        public int EquipoLocalId { get; set; }
                
        public int puntos {  get; set; }
        public int GF { get; set; }
        public int GC { get; set; }
        public int diferencia { get; set; }
        public int partidosJugados {  get; set; }

    }
}
