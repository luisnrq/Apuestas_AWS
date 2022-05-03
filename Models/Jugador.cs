using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apuestas_AWS.Models
{
    [Table("JUGADORES")]
    public class Jugador
    {
        [Key]
        [Column("IDJUGADOR")]
        public int IdJugador { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("POSICION")]
        public string Posicion { get; set; }

        [Column("IMAGEN")]
        public string Imagen { get; set; }

        [Column("IDEQUIPO")]
        public int IdEquipo { get; set; }
    }
}
