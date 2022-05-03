using Apuestas_AWS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apuestas_AWS.Data
{
    public class ApuestasContext: DbContext
    {
        public ApuestasContext(DbContextOptions<ApuestasContext> options) : base(options) { }

        public DbSet<Apuesta> Apuestas { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Jugador> Jugador { get; set; }
    }
}
