using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Modelos
{
    public class Torneo
    {
        [Key] public int ID { get; set; }  

        public String fechaInicio { get; set; }
        public String fechaFin { get; set; }    
        public string Nombre { get; set; }

        public int TipoId {  get; set; }
        public int EquipoId {  get; set; }

        public TipoTorneo? TipoTorneo { get; set; }
                
        public ICollection<TorneoEquipo> Equipos { get; set; }

        public ICollection<Partido> Partido { get; set; }

        }
}
