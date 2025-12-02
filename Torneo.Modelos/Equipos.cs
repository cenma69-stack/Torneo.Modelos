using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Modelos
{
    public class Equipos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Navegación
        public ICollection<Jugador> Jugadores { get; set; }
        public ICollection<Torneo> Torneo { get; set; }
    }
}
