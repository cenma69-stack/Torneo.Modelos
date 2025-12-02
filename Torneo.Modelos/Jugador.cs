using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Modelos
{
    internal class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EquipoId { get; set; }

        // Propiedad de navegación
        public Equipos? Equipo { get; set; }
        public int Goles { get; set; }
        public int TarjetasAmarillas { get; set; }
        public int TarjetasRojas { get; set; }
        public int PartidosSuspendido { get; set; }
    }
}
