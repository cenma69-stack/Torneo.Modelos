using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Torneo.Modelos;

    public class TorneoAPIContext : DbContext 
    {
        public TorneoAPIContext (DbContextOptions<TorneoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Torneo.Modelos.Torneo> Torneo { get; set; } = default!;

public DbSet<Torneo.Modelos.Partido> Partido { get; set; } = default!;

public DbSet<Torneo.Modelos.Equipos> Equipos { get; set; } = default!;

public DbSet<Torneo.Modelos.Jugador> Jugador { get; set; } = default!;

public DbSet<Torneo.Modelos.TipoTorneo> TipoTorneo { get; set; } = default!;

public DbSet<Torneo.Modelos.TorneoEquipo> TorneoEquipo { get; set; } = default!;
    }
