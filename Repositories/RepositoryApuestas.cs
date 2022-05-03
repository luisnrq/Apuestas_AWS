using Apuestas_AWS.Data;
using Apuestas_AWS.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apuestas_AWS.Repositories
{
    public class RepositoryApuestas
    {
        ApuestasContext context;
        string urlBucket;

        public RepositoryApuestas(ApuestasContext context, IConfiguration configuration)
        {
            this.context = context;
            this.urlBucket = configuration.GetValue<string>("AWS:UrlBucket");
        }

        public List<Jugador> GetJugadoresEquipo(int idequipo)
        {
            var consulta = from datos in this.context.Jugador
                           where datos.IdEquipo == idequipo
                           select datos;
            return consulta.ToList();
        }

        public List<Equipo> GetEquipos()
        {
            var consulta = from datos in this.context.Equipos
                           select datos;
            return consulta.ToList();
        }

        public List<Apuesta> GetApuestas()
        {
            var consulta = from datos in this.context.Apuestas
                           select datos;
            return consulta.ToList();
        }

        private int GetMaxIdJugador()
        {
            if (this.context.Jugador.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Jugador.Max(z => z.IdJugador) + 1;
            }
        }

        public void InsertarJugador(string nombre, string posicion, int idequipo, string imagen)
        {
            Jugador j = new Jugador 
            {
                IdJugador = this.GetMaxIdJugador(),
                Nombre = nombre,
                Posicion = posicion,
                Imagen = imagen,
                IdEquipo = idequipo
            };
            this.context.Jugador.Add(j);
            this.context.SaveChanges();
        }

        private int GetMaxIdApuesta()
        {
            if (this.context.Apuestas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Apuestas.Max(z => z.IdApuesta) + 1;
            }
        }

        public void InsertarApuesta(string usuario, int idEquipoLocal, int idEquipoVisitante, int golesEquipoLocal, int golesEquipoVisitante)
        {
            Apuesta a = new Apuesta
            {
                IdApuesta = this.GetMaxIdApuesta(),
                Usuario = usuario,
                IdEquipoLocal = idEquipoLocal,
                IdEquipoVisitante = idEquipoVisitante,
                GolesEquipoLocal = golesEquipoLocal,
                GolesEquipoVisitante = golesEquipoVisitante
            };
            this.context.Apuestas.Add(a);
            this.context.SaveChanges();
        }
    }
}
