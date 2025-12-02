using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Modelos
{
    internal class Partido
    {
        [Key] public int Id { get; set; }
        public int EquiposId { get; set; }


    }
}
