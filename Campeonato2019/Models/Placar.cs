using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato2019.Models
{
    public class Placar
    {
        public int PlacarId { get; set; }

        public int AtletaId { get; set; }

        public virtual Atleta Atleta { get; set; }

        public uint Pontos { get; set; }

        public DateTime Data { get; set; }
    }
}
