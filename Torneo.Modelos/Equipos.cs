using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Modelos
{
    public class Equipos
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
                           
        public ICollection<Jugador> Jugador { get; set; }
               
        public ICollection<TorneoEquipo> Torneo { get; set; }
    }
}
