using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Modelos
{
    public class TorneoEquipo
    {
        
        [Key] public int TorneoId { get; set; }
        public Torneo Torneo { get; set; }

        public int EquipoId { get; set; }
        public Equipos Equipo { get; set; }

        
        public int Puntos { get; set; }
        public int PartidosJugados { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
    }
}
